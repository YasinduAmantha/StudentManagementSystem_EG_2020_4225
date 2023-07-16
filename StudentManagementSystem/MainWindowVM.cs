using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagementSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace StudentManagementSystem
{
    public partial class MainWindowVM : ObservableObject
    {

        public Action CloseAction { get; set; }
        public Action MinimizeAction { get; set; }

        [ObservableProperty]
        public ObservableCollection<Student> students;
        [ObservableProperty]
        public Student selectedStudent = null;

        public MainWindowVM()
        {
            students = new ObservableCollection<Student>();

            BitmapImage image1 = new BitmapImage(new Uri("/icons/1.png", UriKind.Relative));
            DateTime dob1 = new DateTime(2000, 12, 31);
            students.Add(new Student("Ryan", "Perera", image1, dob1, "3.0"));

            BitmapImage image2 = new BitmapImage(new Uri("/icons/2.png", UriKind.Relative));
            DateTime dob2 = new DateTime(2000, 09, 21);
            students.Add(new Student("Nithil", "Sheshan", image2, dob2, "2.6"));

            BitmapImage image3 = new BitmapImage(new Uri("/icons/3.png", UriKind.Relative));
            DateTime dob3 = new DateTime(1999, 04, 12);
            students.Add(new Student("Pasindu", "Pemsiri", image3, dob3, "3.7"));

            BitmapImage image4 = new BitmapImage(new Uri("/icons/4.png", UriKind.Relative));
            DateTime dob4 = new DateTime(1999, 07, 08);
            students.Add(new Student("Lasith", "Perera", image4, dob4, "2.8"));
        }

        [RelayCommand]
        public void CloseWindow()
        {
            CloseAction();
        }

        [RelayCommand]
        public void MinimizeWindow()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        [RelayCommand]
        public void InsertStudent()
        {

            var vm = new InsertWindowVM();
            InsertWindow window = new InsertWindow(vm);
            window.ShowDialog();

            if (vm.Member == null)
            {

            }

            else
            {
                students.Add(vm.Member);
            }

        }



        public Student Selectedsstudent
        {
            get => selectedStudent;
            set
            {
                if (value != selectedStudent)
                {
                    selectedStudent = value;
                    OnPropertyChanged(nameof(Selectedsstudent));
                }
            }
        }

        public ObservableCollection<Student> sstudents
        {
            get => students;
            set
            {
                if (value != students)
                {
                    students = value;
                    OnPropertyChanged(nameof(sstudents));
                }
            }
        }

        [RelayCommand]
        public void DetailEditStudent(object obj)
        {
            if (obj is Student student)
            {
                var vm = new EditStudentVM(student);
                var window = new EditStudent(vm);

                window.ShowDialog();


                int index = students.IndexOf(student);
                students.RemoveAt(index);
                students.Insert(index, vm.Member);

                Selectedsstudent = vm.Member;

            }

        }

        [RelayCommand]
        public void DeleteStudent(object obj)
        {
            if (obj is Student student)
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {student.FirstName}?", "Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    string fname = student.FirstName;
                    string lname = student.LastName;
                    students.Remove(student);
                    MessageBox.Show($"Dataset of {fname} {lname} is deleted successfully.", "Delletion Process");
                }
            }
        }

    }
}










