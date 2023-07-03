using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace GameStoreClient.ViewModels
{
    public class CustomWindowBarVM:BaseVM
    {
        public ICommand CloseWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        public CustomWindowBarVM()
        {
            CloseWindowCommand = new RelayCommand<UserControl>((p) => { return p != null; }, (p) => {
                FrameworkElement window = getWindowParent(p);
                var w = window as Window;
                if (w != null)
                {
                    w.Close();
                }
            }
            );
            MinimizeWindowCommand = new RelayCommand<UserControl>((p) => { return p != null; }, (p) => {
                FrameworkElement window = getWindowParent(p);
                var w = window as Window;
                if (w != null)
                {
                    w.WindowState = WindowState.Minimized;
                }
            }
            );
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
    }
}
