using MaterialDesignThemes.Wpf;
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

namespace GameStoreClient
{
    /// <summary>
    /// Interaction logic for NavigationRaill.xaml
    /// </summary>
    public partial class NavigationRail : UserControl
    {
        public List<RailItem> SampleList { get; set; } = new List<RailItem>()
        {
            new RailItem(PackIconKind.Home,PackIconKind.HomeOutline,"Home",null),
            new RailItem(PackIconKind.Store,PackIconKind.StoreOutline,"Store",null),

        };
        public NavigationRail()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
    public class RailItem
    {
        public RailItem() { 
        }

        public RailItem(PackIconKind? unselectedIcon, PackIconKind? selectedIcon, string? title, string? notification)
        {
            SelectedIcon = selectedIcon;
            Notification = notification;
            Title = title;
            UnselectedIcon = unselectedIcon;
        }

        public PackIconKind? SelectedIcon { get; set; }
        public string? Title { get; set; }
        public string? Notification { get; set; }
        public PackIconKind? UnselectedIcon { get; set; }
    }
}
