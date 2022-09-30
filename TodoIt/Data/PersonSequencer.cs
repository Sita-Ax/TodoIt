using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoConsoleApp.Data
{
    public class PersonSequencer
    {
        //Private field int
        private static int personId;

        //Method to get the get and set
        public static int PersonId
        {
            get { return personId; }
            set { personId = value; }
        }

        //The method that increment personId and return next value
        public static int NextPersonId()
        {
            personId++;
            return personId;
        }

        //The method that set the personId to 0
        public static void Reset()
        {
            personId = 0;
        }
    }
}
