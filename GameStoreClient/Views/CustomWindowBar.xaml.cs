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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameStoreClient.Views
{
    /// <summary>
    /// Interaction logic for CustomWindowBar.xaml
    /// </summary>
    public partial class CustomWindowBar : UserControl
    {
        public CustomWindowBar()
        {
            InitializeComponent();
           this.DataContext = new CustomWindowBarVM();
        }
        FrameworkElement getWindowParent(UserControl p)
        {
            FrameworkElement parent = p;
            while (parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }
            return parent;
        }
        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement p = getWindowParent((UserControl)sender);

            if (e.ChangedButton == MouseButton.Left)
                (p as Window).DragMove() ;

        }
    }
}
