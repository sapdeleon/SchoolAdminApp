using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolAdmin
{
    class Utility
    {
        static public string Ask(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }
        static public int AskInt(string question)
        {
            Console.Write(question);
            return int.Parse(Console.ReadLine());
        }
        static public void Say(string msg)
        {
            Console.WriteLine(msg);
        }
        static public void Write(string msg)
        {
            Console.Write(msg);
        }
        static public bool ExitNow()
        {
            Console.Write("Add another student? y/n :--> ");
            return (Console.ReadLine() != "n");
        }
    }
}
