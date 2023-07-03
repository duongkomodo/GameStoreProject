using DataAccess.Dto;
using GameStoreClient.ViewModels.HomeWindow;
using GameStoreClient.ViewModels.ListGameWindow;
using GameStoreClient.Views;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Input;
namespace GameStoreClient.ViewModels.NavigationWindow
{
    public class NavigationVM: BaseVM
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
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
        private void Home(object obj) => CurrentView = new HomeVM();
        private void ListGame(object obj) => CurrentView = new ListGameVM();
        private void UserInfo(object obj) => CurrentView = new UserInfoVM();
        private void GameDetail(DisplayGameDto obj) => CurrentView = new GameDetailVM(obj);
        public ICommand HomeCommand { get; set; }
        public ICommand SearchGameCommand { get; set; }
        public ICommand ListGameCommand { get; set; }
        public ICommand GameDetailCommand { get; set; }
        public ICommand UserInfoCommand { get; set; }
        public ICommand LoginSignUpCommand { get; set; }
        public NavigationVM()
        {
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
                UserInfo(p);
            });
            LoginSignUpCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                SignInSignUpWindow signInSignUpWindow = new SignInSignUpWindow();
                signInSignUpWindow.ShowDialog();
            });
            SearchGameCommand = new RelayCommand<object>((p) =>
            {
                return true;
            },  (p) =>
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
