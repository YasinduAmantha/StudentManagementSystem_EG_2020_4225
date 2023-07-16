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

namespace StudentManagementSystem
{

    

    public partial class EditStudentVM : ObservableObject
    {

        [ObservableProperty]
        public string first_name;
        [ObservableProperty]
        public string last_name;
        [ObservableProperty]
        public BitmapImage selected_image;
        [ObservableProperty]
        public DateTime selected_date_time;
        [ObservableProperty]
        public string gpa01;

        public EditStudentVM(Student stud)
        {
            Member = stud;

            first_name = Member.FirstName;
            last_name = Member.LastName;
            selected_image = Member.Image;
            selected_date_time = Member.DOB;
            gpa01 = Member.GPA;

        }

        public Student Member { get; private set; }



        public EditStudentVM()
        {
            selected_date_time = DateTime.Now;
        }

        public Action CloseAction { get; internal set; }


        //get image 
        [RelayCommand]
        public void ImageUpload()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                Selected_image = new BitmapImage(new Uri(dialog.FileName));
                MessageBox.Show("Image successfully uploaded!", "Success");
            }
        }



        [RelayCommand]
        public void SaveStudent()
        {
            try
            {
                if (!Regex.IsMatch(first_name, @"^[a-zA-Z\s]+$") || !Regex.IsMatch(last_name, @"^[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("First name and last name must contain only letters and spaces.", "Error");
                    return;
                }

                if (string.IsNullOrEmpty(first_name) || string.IsNullOrEmpty(last_name) || selected_date_time == null || selected_image == null || selected_image.ToString() == "pack://application:,,,/icons/upload.jpg")
                {
                    MessageBox.Show("Please fill in all required fields and select an image.", "Error");
                    return;
                }


                double gpaCheck;
                if (!double.TryParse(gpa01, out gpaCheck) || gpaCheck < 0 || gpaCheck > 4)
                {
                    MessageBox.Show("GPA value is not valid!!! GPA value must be a number between 0 and 4.", "Error");
                    return;
                }

                if (Member == null)
                {
                    Member = new Student()
                    {
                        FirstName = first_name,
                        LastName = last_name,
                        Image = selected_image,
                        DOB = selected_date_time,
                        GPA = gpa01
                    };
                }

                else
                {
                    Member.FirstName = first_name;
                    Member.LastName = last_name;
                    Member.Image = selected_image;
                    Member.DOB = selected_date_time;
                    Member.GPA = gpa01;
                }

                if (Member.FirstName != null)
                {
                    CloseAction();
                }
                Application.Current.MainWindow.Show();
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }

        }
    }
}
