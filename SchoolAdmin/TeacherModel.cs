using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolAdmin
{
    public class TeacherModel : MemberModel, IDisplay
    {
        public string Subject { get; set; }

        public TeacherModel() { }

        public void ShowInfo()
        {
            Console.WriteLine($"Teacher Name: {Name}, Subject: {Subject}");
        }
    }
}
