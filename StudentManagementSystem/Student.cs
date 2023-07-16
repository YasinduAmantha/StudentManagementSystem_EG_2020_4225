using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace StudentManagementSystem
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public BitmapImage Image { get; set; }
        public DateTime DOB { get; set; }
        public string GPA { get; set; }

        public string ImageURL
        {
            get { return $"/icons/{Image}"; }
        }

        public Student(string firstName, string lastName, BitmapImage image, DateTime dob, string gpa) 
        {
            FirstName = firstName;
            LastName = lastName;
            Image = image;
            DOB = dob;
            GPA = gpa;
        }

        public Student()
        {

        }
    }
}
