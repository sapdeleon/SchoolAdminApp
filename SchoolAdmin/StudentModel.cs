using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolAdmin
{
    public class StudentModel : MemberModel, IDisplay
    {
        public int Grade { get; set; }

        public StudentModel() { }

        public void ShowInfo()
        {
            Console.WriteLine($"Student Name: {Name}, Grade: {Grade}");
        }
    }
}
