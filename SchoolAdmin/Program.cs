using System;
using System.Collections.Generic;

namespace SchoolAdmin
{
    enum Entry { Student, Teacher, Principal }
    enum Menu { Records, Data }

    class Program
    {
        // static public List<StudentModel> students = new List<StudentModel>();
        // static public List<TeacherModel> teachers = new List<TeacherModel>();
        // static public List<PrincipalModel> principals = new List<PrincipalModel>();

        static public DbUtil db = new DbUtil("SchoolDB");

        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            Utility.Say("School Administration Application");
            Utility.Write("Select Category: \n [0] - Show Records \n [1] - Data Entry \n [2] - Exit \n :--> ");

            Menu menu = (Menu)int.Parse(Console.ReadLine());

            switch (menu)
            {
                case Menu.Records:
                    ShowRecords();
                    break;
                case Menu.Data:
                    DataEntry();
                    break;
                default:
                    break;
            }
        }

        static void ShowRecords()
        {
            Utility.Say("Show Records Application");
            Utility.Write("Select Records: \n [0] - Students \n [1] - Teachers \n [2] - Principals \n :-> ");

            Entry entry = (Entry)int.Parse(Console.ReadLine());
            ShowRecords(entry);
        }

        static void ShowRecords(Entry entry)
        {
            switch (entry)
            {
                case Entry.Student:
                    var students = db.LoadRecords<StudentModel>("Student");
                    Utility.Say("*** Student's Records ***");
                    foreach (var student in students)
                    {
                        student.ShowInfo();
                    }
                    MainMenu();
                    break;
                case Entry.Teacher:
                    var teachers = db.LoadRecords<TeacherModel>("Teacher");
                    Utility.Say("*** Teacher's Records ***");
                    foreach (var teacher in teachers)
                    {
                        teacher.ShowInfo();
                    }
                    MainMenu();
                    break;
                case Entry.Principal:
                    var principals = db.LoadRecords<PrincipalModel>("Principal");
                    Utility.Say("*** Principal's Records ***");
                    foreach (var principal in principals)
                    {
                        principal.ShowInfo();
                    }
                    MainMenu();
                    break;
            }
        }

        static void DataEntry()
        {
            Utility.Say("School Administration Application");
            Utility.Write("New Member Entry: \n [0] - New Student Entry \n [1] - New Teacher Entry \n [2] - New Principal Entry \n :-> ");
            
            Entry entry = (Entry) int.Parse(Console.ReadLine());
            
            switch (entry)
            {
                case Entry.Student: // new student entry
                    Utility.Say("*** New Student Entry Form ***");
                    NewStudentEntry();
                    break;
                case Entry.Teacher: // new teacher entry
                    Utility.Say("*** New Teacher Entry Form ***");
                    NewTeacherEntry();
                    break;
                case Entry.Principal: // new principal entry
                    Utility.Say("*** New Principal Entry Form ***");
                    NewPrincipalEntry();
                    break;
            }
        }

        static void NewStudentEntry()
        {
            bool adding = true;

            while (adding)
            {
                StudentModel newStudent = new StudentModel();
                newStudent.Name = Utility.Ask("Enter student name: ");
                newStudent.Grade = Utility.AskInt("Enter student grade: ");
                
                // students.Add(newStudent);
                
                db.InsertRecord("Student", new StudentModel 
                { 
                    Name = newStudent.Name,
                    Grade = newStudent.Grade
                });

                newStudent.ShowInfo();

                adding = Utility.ExitNow();
            }
            MainMenu();
        }

        static void NewTeacherEntry()
        {
            bool adding = true;

            while (adding)
            {
                TeacherModel newTeacher = new TeacherModel();
                newTeacher.Name = Utility.Ask("Enter teacher name: ");
                newTeacher.Subject = Utility.Ask("Enter teacher subject: ");
                
                // teachers.Add(newTeacher);

                db.InsertRecord("Teacher", new TeacherModel
                {
                    Name = newTeacher.Name,
                    Subject = newTeacher.Subject
                });

                newTeacher.ShowInfo();

                adding = Utility.ExitNow();
            }
            MainMenu();
        }

        static void NewPrincipalEntry()
        {
            bool adding = true;

            while (adding)
            {
                PrincipalModel newPrincipal = new PrincipalModel();
                newPrincipal.Name = Utility.Ask("Enter principal name: ");
                Utility.Write("Select school: \n [0] - Little Rouge \n [1] - Sam Chapman \n [2] - Bill Hogart \n :--> ");
                newPrincipal.School = (School)Utility.AskInt("Enter principal school: ");
                
                // principals.Add(newPrincipal);

                db.InsertRecord("Principal", new PrincipalModel
                {
                    Name = newPrincipal.Name,
                    School = newPrincipal.School
                });

                newPrincipal.ShowInfo();

                adding = Utility.ExitNow();
            }
            MainMenu();
        }
    }
}
