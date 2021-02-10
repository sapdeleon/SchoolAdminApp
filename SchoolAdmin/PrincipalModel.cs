using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolAdmin
{
    public class PrincipalModel : MemberModel, IDisplay
    {
        public PrincipalModel() { }

        public void ShowInfo()
        {
            Console.WriteLine($"Principal Name: {Name}, School: {School}");
        }
    }
}
