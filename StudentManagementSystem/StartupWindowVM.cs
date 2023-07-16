using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Diagnostics.Metrics;

namespace StudentManagementSystem
{
    public partial class StartupWindowVM : ObservableObject
    {
        public StartupWindowVM()
        { 
        }

        public Action CloseAction { get; set; }

        [RelayCommand]
        public void MinimizeWindow()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        [RelayCommand]
        public void CloseWindow()
        {
            CloseAction();
        }

        [RelayCommand]
        public void login()
        {
            var window = new MainWindow();
            CloseAction();
            window.ShowDialog();
        }
    }
}