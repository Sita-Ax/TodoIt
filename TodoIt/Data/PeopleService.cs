using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoConsoleApp.Models;

namespace TodoConsoleApp.Data
{
    public class PeopleService
    {
        //An array 
        private static Person[] personArray = new Person[0];

        public Person[] PersonArray 
            { 
                get 
                {
                    return personArray;
                } 
                set 
                { 
                    personArray = value; 
                }
            }

        //This will return all things inside the person array
        public int Size()
        {
            return personArray.Length;
        }
        
        //To find all person
        public Person[] FindAll()
        {
            return personArray;
        }

        //Looked for the persons Id and compare to the Id I want to find.
        public Person? FindById(int personId)
        {
            foreach (Person person in personArray)
            {
                if (person.PersonId == personId)
                {
                    return person;
                }
            }
            return null;
        }

        //Method to create a new person and send in parameters inside this that belongs to the person

        public Person CreateNewPerson(string firstName, string lastName)
        {
            //create a new person, make uniq Id by call the NextPersonId method and give firstname and lastname
            Person newPerson = new Person(firstName, lastName, PersonSequencer.NextPersonId());
            //Resize my array
            Array.Resize<Person>(ref personArray, personArray.Length + 1);
            //Put my new person into my resized array
            personArray[personArray.Length - 1] = newPerson;
            //Get the new person
            return newPerson;
        }

        public void RemovePersonId(int personId)
        {
            for (int i = 0; i < personArray.Length; i++)    //look in to personarray
            {
                if (personArray[i].PersonId == personId)//inside array I look at the todo and the id. 
                {
                    for (int offset = i + 1; offset < personArray.Length; offset++, i++)
                    {
                        personArray[i] = personArray[offset];
                    }
                    Array.Resize(ref personArray, personArray.Length - 1);
                    break;
                }
            }
        }

        public void Clear()
        {
            personArray = new Person[0];
        }
    }
}
