using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoIt.Data;
using TodoIt.Models;

namespace TodoIt.ModelsTest
{
    public class TodoTest 
    {
        public TodoTest()
        {
         
        }
        [Fact]
        public void TodoClassTest()
        {
            //Arrange
            string description1 = "Finish assignment";
            string description2 = "Go for walk";

            //Act
            Todo testTodo1 = new Todo(TodoSequencer.NextTodoId(), description1);
            Todo testTodo2 = new Todo(TodoSequencer.NextTodoId(), description2);

            //Assert

            Assert.Equal(description1, testTodo1.Description);
            Assert.Equal(description2, testTodo2.Description);


        }
        [Fact]
        public void TestTodoId()
        {
            //Arrange
            Todo todo = new Todo(0, "Description");
            //Act
            int todoId = 0;
            //Assert
            Assert.Equal(0, todo.TodoId);
        }

        [Fact]
        public void TestTodoDescrption()
        {
            //Arrange
            Todo todo = new Todo(0, "Description");
            //Act
            string? actual = todo.Description;
            //Assert
            Assert.Equal("Description", actual);
        }
        /*
        [Fact]
        public void TestBoolDone()
        {
            //Arrange
            Todo todo = new Todo(0, "Description");
            //Act
            bool actual = todo.Done;
            //Assert
            Assert.True(actual);
        }
        */
    }
}
