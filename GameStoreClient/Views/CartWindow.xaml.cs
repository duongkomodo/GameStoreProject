using GameStoreClient.ViewModels;
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
    /// Interaction logic for CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        public CartWindow(UserCartVM cartVM)
        {
            InitializeComponent();
            this.DataContext = cartVM;
            if (cartVM.CloseWindowAction == null)
                cartVM.CloseWindowAction = new Action(Close);
        }
    }
}
