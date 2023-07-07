using DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GameStoreClient.ViewModels
{
    public class UserCartVM : BaseVM
    {

        #region Property
        private ObservableCollection<UserCartDto> _localUserCart;
        public ObservableCollection<UserCartDto> LocalUserCart
        {
            get
            {
                return _localUserCart;
            }
            set
            {
                _localUserCart = value; OnPropertyChanged();
            }
        }
        private ObservableCollection<UserCartDto> _loginUserCart;
        public ObservableCollection<UserCartDto> LoginUserCart
        {
            get
            {
                return _loginUserCart;
            }
            set
            {
                _loginUserCart = value; OnPropertyChanged();
            }
        }
        #endregion

        #region Function
        #endregion

        #region Command
        #endregion

        public UserCartVM()
        {
        }
    }
}
