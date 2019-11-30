using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Protected_App
{
    class Agent
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int AccessLevel { get; set; }
        public Agent(string firstName, string secondName, string lastName, int accessLevel)
        {
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            FullName = FirstName + " " + SecondName + " " + LastName;
            AccessLevel = accessLevel;
        }
    }
}
