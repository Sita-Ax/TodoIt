using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoIt.Data;
using TodoIt;
using TodoIt.Models;

namespace TodoIt.DataTest
{
    public class PeopleServiceTest
    {
        PeopleService peopleCase;
        public PeopleServiceTest()
        {
            peopleCase = new PeopleService();
        }
        
        [Fact]
        public void SizeTest()
        {
            //Arrange
            PeopleService peopleTesting = new PeopleService();
            peopleTesting.Clear();
            peopleTesting.CreateNewPerson("Lina", "Lunn");

            int expected = peopleCase.Size();
            int expSize = 1;
            //Act
            int actuelly = peopleCase.Size();
            int actSize = peopleTesting.Size();
            //Assert
            Assert.Equal(expected, actuelly);
            Assert.Equal(expSize, actSize);
        }

        [Fact]
        public void FindAllTest()
        {
            //Arrange
            Person[] expected = peopleCase.FindAll();

            //Act
            Person[] actuelly = peopleCase.FindAll();
            //Assert
            Assert.Equal(expected.ToString(), actuelly.ToString());
        }

        [Fact]
        public void FindAllPeopleTest()
        {
            //Arrange            
            PeopleService testingPeople = new PeopleService();
            testingPeople.Clear();

            testingPeople.CreateNewPerson("Fred", "Lindberg");
            testingPeople.CreateNewPerson("Anna", "Molin");
            testingPeople.CreateNewPerson("Jens", "Schmidth");
            int expectedSize = 3;
            //Act
            Person[] foundPersons = testingPeople.FindAll();

            //Assert
            Assert.Equal(expectedSize, foundPersons.Length);
        }

        [Fact]

        public void FindByIdTest()
        {
            //Arrange
            PeopleService personTesting = new PeopleService();
            Person person1 = personTesting.CreateNewPerson("Rosita", "Axelsson");
            Person person2 = personTesting.CreateNewPerson("Ann", "Lind");
            int checkPersonId = person2.PersonId;
           
            //Act
            Person matchPerson = personTesting.FindById(checkPersonId);

            //Assert
            Assert.NotEqual(matchPerson, person1);
            Assert.Equal(matchPerson, person2);
        }

        [Fact]

        public void CreateNewPersonTest()
        {
            PeopleService testingPeople = new PeopleService();
            testingPeople.Clear();
            string firstName1 = "Hanna";
            string lastName1 = "Ljung";
            string firstName2 = "Mona";
            string lastName2 = "Lund";

            //Act
            Person testPerson1 = testingPeople.CreateNewPerson(firstName1, lastName1);
            Person testPerson2 = testingPeople.CreateNewPerson(firstName2, lastName2);

            //Assert
            Assert.Equal(firstName1, testPerson1.FirstName);
            Assert.Equal(lastName1, testPerson1.LastName);

            Assert.Equal(firstName2, testPerson2.FirstName);
            Assert.Equal(lastName2, testPerson2.LastName);
        }


        [Fact]
        public void RemovePersonTest()
        {
            //Arrange
            PeopleService testPerson = new PeopleService();

            Person testPerson1 = testPerson.CreateNewPerson("Maja", "Ljung");
            Person testPerson2 = testPerson.CreateNewPerson("Ludwig", "Hallberg");
            Person testPerson3 = testPerson.CreateNewPerson("Anna", "Larsson");


            //Act
            testPerson.RemovePersonId(testPerson2.PersonId);

            //Assert
            Assert.Contains(testPerson1, testPerson.FindAll());
            Assert.DoesNotContain(testPerson2, testPerson.FindAll());
            Assert.Contains(testPerson3, testPerson.FindAll());
        }


        [Fact]
        public void ClearTest()
        { 
            PeopleService peopleService = new PeopleService();
            peopleService.PersonArray = new Person[0];

            Person[] personArray = peopleCase.FindAll();
            Assert.False(personArray.Length > 0, "Nothing inside.");
        }

    }
}
