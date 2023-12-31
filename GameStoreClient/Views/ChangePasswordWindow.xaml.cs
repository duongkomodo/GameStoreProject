﻿using System;
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
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow(ViewModels.UserInfoVM userInfoVM)
        {
            InitializeComponent();
            this.DataContext = userInfoVM;
        
            if (userInfoVM.CloseChangePasswordWindowAction == null)
                userInfoVM.CloseChangePasswordWindowAction = new Action(Close);
        }
    }
}
