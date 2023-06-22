using GameStoreClient.ViewModels.HomeWindow;
using GameStoreClient.ViewModels.ListGameWindow;
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

        private void Home(object obj) => CurrentView = new HomeVM();
        private void ListGame(object obj) => CurrentView = new ListGameVM();
        private void UserInfo(object obj) => CurrentView = new UserInfoVM();
        public ICommand HomeCommand { get; set; }
        public ICommand ListGameCommand { get; set; }
        public ICommand UserInfoCommand { get; set; }

        public NavigationVM()
        {

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


            // Startup Page
            CurrentView = new HomeVM();
        }
    }
}
