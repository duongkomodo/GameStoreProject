using GameStoreClient.ViewModels.HomeWindow;
using GameStoreClient.ViewModels.NavigationWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameStoreClient.Views
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public NavigationVM NaviVM { get; }
        public HomeWindow()
        {
            InitializeComponent();
            NaviVM= new NavigationVM();
            this.DataContext = NaviVM;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            NaviVM.LogoutCommand.Execute(null);
        }
    }
}
