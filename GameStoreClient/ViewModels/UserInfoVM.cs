using DataAccess.Dto;
using GameStoreClient.APIHelper;
using GameStoreClient.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GameStoreClient.ViewModels
{
    public class UserInfoVM : BaseVM
    {
        #region Property
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
        #endregion
        #region Function
        private async void LoadUserInfo()
        {
            if (UserData.User != null && UserData.Jwt!=null)
            {
                UserInfor = await SendApiRequest.SendApiRequestAsync<UserDto>
   ($"https://localhost:7142/api/User/GetUserInformation?userName={UserData.User.Email}", HttpMethod.Get, null, UserData.Jwt);
            }
         
        }
        #endregion
        #region Command
        public ICommand ChangePasswordCommand { get; set; }
        #endregion
        public UserInfoVM()
        {
            LoadUserInfo();
            ChangePasswordCommand = new RelayCommand<object>((p) =>
            {
                return true;
            },  (p) =>
            {
                ChangePasswordWindow changePassword = new ChangePasswordWindow(this);
                changePassword.ShowDialog();
            });
        }
    }
}
