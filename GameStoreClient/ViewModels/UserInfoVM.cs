using DataAccess.Dto;
using DataAccess.Utility;
using GameStoreClient.APIHelper;
using GameStoreClient.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace GameStoreClient.ViewModels
{
    public class UserInfoVM : BaseVM
    {
        #region Property
        public Action CloseChangePasswordWindowAction { get; set; }
        private UserDto _userInfor;
        public UserDto UserInfor
        {
            get { return _userInfor; }
            set
            {
                _userInfor = value;
                OnPropertyChanged();
            }
        }
        private ChangePasswordDto _changePasswordData = new ChangePasswordDto();
        public ChangePasswordDto ChangePasswordData
        {
            get { return _changePasswordData; }
            set
            {
                _changePasswordData = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Function
        private async void LoadUserInfo()
        {
            if (UserData.User != null && UserData.Jwt != null)
            {
                UserInfor = await SendApiRequest.SendApiRequestAsync<UserDto>
   ($"https://localhost:7142/api/User/GetUserInformation?userName={UserData.User.Email}", HttpMethod.Get, null, UserData.Jwt);
    
            }
        }
        #endregion
        #region Command
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand SaveChangePasswordCommand { get; set; }

        public ICommand SaveChangeUpdateInforCommand { get; set; }
        public ICommand UploadImageCommand { get; set; }
        #endregion
        public UserInfoVM()
        {
            LoadUserInfo();
            UploadImageCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, async (p) =>
            {
            // Create OpenFileDialog
            OpenFileDialog dlg = new OpenFileDialog();
                dlg.Multiselect = false;
            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";

            // Display OpenFileDialog by calling ShowDialog method
           bool? result = dlg.ShowDialog();

                if (result == true)
                {
                    // Open document
                    string filepath = dlg.FileName; // Stores Original Path in Textbox
                    string ext = System.IO.Path.GetExtension(filepath);
                    var file = File.ReadAllBytes(filepath);
                
                    string fileName = dlg.SafeFileName;
                    var fileSize = file.Length;
                    if (!((fileSize / 1048576.0) < 5))
                    {
                        DisplayMessageBox.Show("File must be less than 5MB!", null, "Upload image Process", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    var check = await SendApiRequest
.UploadImageAsync($"https://api.upload.io/v2/accounts/kW15bYA/uploads/binary?filePath=/Avatar/{UserInfor.Id}{ext}", file, StringText.UploadImageKey);

                    if (check == null)
                    {
                        DisplayMessageBox.Show("Upload image fail!", null, "Upload image Process", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    if (check != null)
                    {
                        UserInfor.Avatar = check.FileUrl;

                    }


                }
            });
            ChangePasswordCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                ChangePasswordWindow changePassword = new ChangePasswordWindow(this);
                changePassword.ShowDialog();
            });
            SaveChangePasswordCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(ChangePasswordData.NewPassword) || string.IsNullOrEmpty(ChangePasswordData.ConfirmPassword))
                {
                    return false;
                }
                return true;
            }, async (p) =>
            {
                ChangePasswordData.Email = UserData.User.Email;
                var result = await SendApiRequest
.SendApiRequestAsync<BaseOutputDto>("https://localhost:7142/api/User/ChangePassword", HttpMethod.Post, ChangePasswordData, UserData.Jwt);
          
                if (result != null && OutputStatus.Fail.Equals(result.Status))
                {
                    DisplayMessageBox.Show(null, result.Messages, "Update Password Process", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    DisplayMessageBox.Show(null, result.Messages, "Update Password Process", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                CloseChangePasswordWindowAction();
            });
            SaveChangeUpdateInforCommand = new RelayCommand<object>((p) =>
            {
              
                return true;
            }, async (p) =>
            {

                var result = await SendApiRequest
       .SendApiRequestAsync<BaseOutputDto>("https://localhost:7142/api/User/UpdateUserInfor", HttpMethod.Post, UserInfor, UserData.Jwt);

            if (result != null && OutputStatus.Fail.Equals(result.Status))
                {
                    DisplayMessageBox.Show(null, result.Messages, "Change Information Process", MessageBoxButton.OK, MessageBoxImage.Information);
                    UserData.User = UserInfor;
                }
                else
                {
                    DisplayMessageBox.Show(null, result.Messages, "Change Information Process", MessageBoxButton.OK, MessageBoxImage.Error);
                }
        
            });
        }
    }
}
