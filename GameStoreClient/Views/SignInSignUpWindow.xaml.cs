﻿using GameStoreClient.ViewModels;
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
    /// Interaction logic for SignInSignUpWindow.xaml
    /// </summary>
    public partial class SignInSignUpWindow : Window
    {
        public SignInSignUpWindow()
        {
            InitializeComponent();
            var vm = new AuthenVM();
            this.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(Close);

        }
    }
}
