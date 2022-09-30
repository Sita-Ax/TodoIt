using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoIt.Models
{
    public class Person
    {
        //use readonly so it can not be changed
        private readonly int personId;  
        //regulary fields to describe the Person class 
        private string? firstName;
        private string? lastName;

        //constructur to reach and ref to this
        public Person(string? firstName, string? lastName, int personId)
        {
            this.personId = personId;
            FirstName = firstName;
            LastName = lastName;
        }
        
        //Method gets and sets properties
        public int PersonId
        {
            get 
            { 
                return personId; 
            }
        }
        public string? FirstName { 
            get 
            { 
                return firstName; 
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("FirstName can´t be null or empty!");
                }
                else
                {
                    firstName = value;
                }
            }
        }
        public string? LastName { 
            get 
            { 
                return lastName; 
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("LastName can´t be null or empty!");
                }
                else
                {
                    lastName = value;
                }
            }
        }

    }
}
