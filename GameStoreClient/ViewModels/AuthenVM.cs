﻿using DataAccess.Dto;
using DataAccess.Utility;
using GameStoreClient.APIHelper;
using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Input;
namespace GameStoreClient.ViewModels
{
    public class AuthenVM : BaseVM
    {
        #region Property   
        public Action CloseAction { get; set; }
        private SignInDto _signInData = new SignInDto();
        public SignInDto SignInData
        {
            get
            {
                return _signInData;
            }
            set
            {
                _signInData = value;
                OnPropertyChanged();
            }
        }
        private SignUpInputDto _signUpData = new SignUpInputDto();
        public SignUpInputDto SignUpData
        {
            get
            {
                return _signUpData;
            }
            set
            {
                _signUpData = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Function
        #endregion
        #region Command
        public ICommand LoginCommand { get; set; }
        public ICommand SignUpCommand { get; set; }
        #endregion
        public AuthenVM()
        {
            LoginCommand = new RelayCommand<object>((p) =>
            {
                if (SignInData.Email != null && SignInData.Password != null)
                {
                    return true;
                }
                return false;
            }, async (p) =>
            {
                if (SignInData != null)
                {
                    BaseOutputDto result = await SendApiRequest
     .SendApiRequestAsync<BaseOutputDto>("https://localhost:7142/api/User/Login", HttpMethod.Post, SignInData);
                    if (result != null)
                    {
                        UserData.Jwt = result.Messages[0].ToString().Replace("\"", "");
                    }
                    if ("Unconfirmed Email".Equals(result.Status))
                    {
                        if (DisplayMessageBox.Show(null, result.Messages, result.Status, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            var resendEmail = await SendApiRequest
    .SendApiRequestAsync<BaseOutputDto>
    ($"https://localhost:7142/api/User/ResendConfirmEmail?email={SignInData.Email}", HttpMethod.Post, null);
                            DisplayMessageBox.Show(null, resendEmail.Messages, resendEmail.Status, MessageBoxButton.OK, resendEmail.Status != OutputStatus.Fail ? MessageBoxImage.Question : MessageBoxImage.Error);
                        };
                    }
                    if (OutputStatus.Fail.Equals(result.Status))
                    {
                        DisplayMessageBox.Show(null, result.Messages, "Login Process Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    if (OutputStatus.Success.Equals(result.Status))
                    {
                        var userInfo = await SendApiRequest
     .SendApiRequestAsync<UserDto>
     ($"https://localhost:7142/api/User/GetUserInformation?userName={SignInData.Email}", HttpMethod.Get, null, UserData.Jwt);
                        if (userInfo != null)
                        {
                            //UserData.Instance.User = userInfo;
                            UserData.User = userInfo;
                        }
                        DisplayMessageBox.Show($"Login success!\nWelcome {SignInData.Email}", null, result.Status, MessageBoxButton.OK, MessageBoxImage.Information);
                        CloseAction();
                    }
                }
            });
            SignUpCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(SignUpData.FirstName)
                || string.IsNullOrEmpty(SignUpData.LastName)
                 || string.IsNullOrEmpty(SignUpData.ConfirmPassword)
                  || string.IsNullOrEmpty(SignUpData.Password)
          )
                {
                    return false;
                }
                return true;
            }, async (p) =>
            {
                if (SignUpData != null)
                {
                    var result = await SendApiRequest
     .SendApiRequestAsync<BaseOutputDto>("https://localhost:7142/api/User/SignUp", HttpMethod.Post, SignUpData);
                    if (OutputStatus.Fail.Equals(result.Status))
                    {
                        DisplayMessageBox.Show(null, result.Messages, "Sign Up Process", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        DisplayMessageBox.Show(null, result.Messages, "Sign Up Process", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            });
        }
    }
}
