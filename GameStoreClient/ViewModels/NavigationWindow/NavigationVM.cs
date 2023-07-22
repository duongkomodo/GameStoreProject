using DataAccess.Dto;
using GameStoreClient.APIHelper;
using GameStoreClient.ViewModels.HomeWindow;
using GameStoreClient.ViewModels.ListGameWindow;
using GameStoreClient.Views;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Input;
namespace GameStoreClient.ViewModels.NavigationWindow
{
    public class NavigationVM : BaseVM
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        private UserCartVM _cartVM;
        public UserCartVM CartVM
        {
            get { return _cartVM; }
            set { _cartVM = value; OnPropertyChanged(); }
        }
        private string _searchBarQuery;
        public string SearchBarQuery
        {
            get
            {
                return _searchBarQuery; 
            }
            set
            {
                _searchBarQuery = value; OnPropertyChanged();
            }
        }

        private  bool _isUserLogined = false;
        public  bool IsUserLogined
        {
            get
            {
                return _isUserLogined;
            }
            set
            {
                _isUserLogined = value;
                OnPropertyChanged();
            }
        }

        private void Home(object obj) => CurrentView = new HomeVM();
        private void ListGame(object obj) => CurrentView = new ListGameVM();
        private void UserInfo(object obj) => CurrentView = new UserInfoVM();
        private void GameDetail(DisplayGameDto obj) => CurrentView = new GameDetailVM(obj);
        public ICommand HomeCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand SearchGameCommand { get; set; }
        public ICommand ListGameCommand { get; set; }
        public ICommand GameDetailCommand { get; set; }
        public ICommand UserInfoCommand { get; set; }
        public ICommand LoginSignUpCommand { get; set; }
        public ICommand ViewCartCommand { get; set; }
        public ICommand AddToCartCommand { get; set; }
        public NavigationVM()
        {
            CartVM = new UserCartVM();
            

            LogoutCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, async (p) =>
            {
                if (UserData.User != null)
                {
                    if (DisplayMessageBox
                .Show("Are you sure want to logout?", null, "Logout", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        CartVM.UnLoadUserCart();
                        await CartVM.SaveUserCartAsync();
                        UserData.Jwt = null;
                        UserData.User = null;
                        IsUserLogined = false;
                        CurrentView = new HomeVM();
                    }

                }
            
             
            });
            AddToCartCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (p != null)
                {
                    var game = p as DisplayGameDto;
                    CartVM.AddToCart(game);
                }
            });
            ViewCartCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                CartWindow cart = new CartWindow(CartVM);
                cart.ShowDialog();
            });
            GameDetailCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var game = p as DisplayGameDto;
                if (game != null) { GameDetail(game); }
            });
            HomeCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                Home(p);
            });
            ListGameCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                ListGame(p);
            });
            UserInfoCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (UserData.User != null )
                {
                    UserInfo(p);
                }
              
            });
            LoginSignUpCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, async (p) =>
            {
                SignInSignUpWindow signInSignUpWindow = new SignInSignUpWindow();
                signInSignUpWindow.ShowDialog();

            if (UserData.User != null)
                {
                    IsUserLogined = true;
                    var userCartItems = await SendApiRequest.SendApiRequestAsync<List<UserCartDto>>
   ($"https://localhost:7142/api/UserCart/LoadAllGamesInUserCart/{UserData.User.Id}", HttpMethod.Get, null, UserData.Jwt);
                    CartVM.LoadUserCart(userCartItems);
                }
            });
            SearchGameCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (CurrentView.GetType() != typeof(ListGameVM))
                {
                    this.ListGameCommand.Execute(null);
                }
               (CurrentView as ListGameVM).SearchGameData(SearchBarQuery);
            });
            // Startup Page
            CurrentView = new HomeVM();
        }
    }
}
