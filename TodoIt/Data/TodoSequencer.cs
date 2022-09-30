using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoConsoleApp.Models;

namespace TodoConsoleApp.Data
{
    public class TodoSequencer
    {
        private static int todoId;
        //Method to get the get and set
        public static int TodoId
        {
            get { return todoId; }
            set { todoId = value; }
        }

        //The method that increment todoId and return next value
        public static int NextTodoId()
        {
            todoId++;
            return todoId;
        }

        //The method that set the todoId to 0
        public static void Reset()
        {
            todoId = 0;
        }
    }
}
