using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoIt.Models
{
    public class Todo
    {
        private readonly int todoId;
        private string? description;
        private bool done;
        private Person assignee;

        public Todo(int todoId, string? description)
        {
            this.todoId = todoId;
            Description = description;
        }

        public int TodoId
        {
            get
            {
                return todoId;
            }
        }

        public string? Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public bool Done
        {
            get
            {
                return done;
            }
            set
            {
                done = value;
            }
        }

        public Person Assignee
        {
            get
            {
                return assignee;
            }
            set
            {
                assignee = value;
            }
        }

    }
}
