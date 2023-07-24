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
    /// Interaction logic for CheckOutPopupWindow.xaml
    /// </summary>
    public partial class CheckOutPopupWindow : Window
    {
        public CheckOutPopupWindow(ViewModels.UserCartVM userCartVM)
        {
            InitializeComponent();
            this.DataContext = userCartVM;
            if (userCartVM.CloseCheckOutPopupAction == null)
                userCartVM.CloseCheckOutPopupAction = new Action(Close);
        }
    }
}
