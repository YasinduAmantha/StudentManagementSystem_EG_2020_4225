using Microsoft.Win32;
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

namespace StudentManagementSystem
{
    /// <summary>
    /// Interaction logic for InsertWindow.xaml
    /// </summary>
    public partial class InsertWindow : Window
    {
        public InsertWindow(InsertWindowVM vm)
        {
            DataContext = vm;
            InitializeComponent();
            vm.CloseAction = () => Close();
        }

       
       

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtFName.Text = string.Empty;
            txtLName.Text = string.Empty;
            txtGPA.Text = string.Empty;
            dtpDob.SelectedDate = null;
            I_box.Source = new BitmapImage(new Uri("pack://application:,,,/icons/upload.jpg"));
        }
    }
}


