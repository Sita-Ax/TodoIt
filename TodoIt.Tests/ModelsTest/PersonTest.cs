using Xunit;
using TodoIt;
using TodoIt.Models;
using TodoIt.Data;
using System;

namespace TodoIt.ModelsTest
{
    public class PersonTest 
    {
        public PersonTest()
        {
        }

        [Fact]
        public void PersonClassTest()
        {
            // Arrange
            string firstName1 = "Sally";
            string lastName1 = "Corey";
            string firstName2 = "Mona";
            string lastName2 = "Carlesson";

            // Act
            Person testPerson1 = new Person(firstName1, lastName1, PersonSequencer.NextPersonId());
            Person testPerson2 = new Person(firstName2, lastName2, PersonSequencer.NextPersonId());

            // Assert        
            Assert.Equal(firstName1, testPerson1.FirstName);
            Assert.Equal(lastName1, testPerson1.LastName);
            Assert.Equal(firstName2, testPerson2.FirstName);
            Assert.Equal(lastName2, testPerson2.LastName);
            //Assert.Equal(1, testPerson1);

        }

        //[Fact]

        //public void TestPersonId()
        //{
        //    //this is my person
        //    Person person = new Person(1, "Nataliia", "Karlsson");

        //    //just an int to check NotEqual
        //    int personId = 0;

        //    //Assert
        //    Assert.NotEqual(personId, personCase.PersonId);
        //    Assert.Equal(1, personCase.PersonId);

        //}


        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void FirstNameBadValueTest(string badFirstName)
        {
            //Arrange
            Person person = new Person("Sam", "Persson", PersonSequencer.NextPersonId());
            //Act
            ArgumentException argument = Assert.Throws<ArgumentException>(() => person.FirstName = badFirstName);
            //Assert
            //Assert.NotEqual(person.FirstName, argument.Message);
            Assert.Contains("FirstName", argument.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void LastNameBadValueTest(string badLastName)
        {
            //Arrange
            Person person = new Person("Sam", "Persson", PersonSequencer.NextPersonId());
            //Act
            ArgumentException argument = Assert.Throws<ArgumentException>(() => person.LastName = badLastName);
            //Assert
            Assert.NotEqual(person.LastName, argument.Message);
            Assert.Contains("LastName", argument.Message);
        }

        [Fact]
        public void TestPersonFirstName()
        {
            //Arrange
            Person person = new Person("Sam", "Persson", PersonSequencer.NextPersonId());
            string? expected = "Sam";
            //Act
            string? actual = person.FirstName;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]

        public void TestPersonLastName()
        {
            //Arrange
            Person person = new Person("Sam", "Persson", PersonSequencer.NextPersonId());
            string? expected = "Persson";
            //Act
            string? actual = person.LastName;
            //Assert
            Assert.Equal(expected, actual);
        }
        
    }
}