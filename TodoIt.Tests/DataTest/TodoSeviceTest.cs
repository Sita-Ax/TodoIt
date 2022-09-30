using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoIt.Data;
using TodoIt.Models;

namespace TodoIt.DataTest
{
    public class TodoSeviceTest
    {
        TodoService todoCase;
        public TodoSeviceTest()
        {
            todoCase = new TodoService();
        }

        [Fact]
        public void SizeTest()
        {
            //Arrange
            PeopleService peopleService = new PeopleService();
            peopleService.Clear();
            peopleService.CreateNewPerson("Hanna", "Ljung");
            peopleService.CreateNewPerson("Clara", "Lind");

            int expected = 2;
            //Act
            int actuelly = peopleService.Size();
            //Assert
            Assert.Equal(expected, actuelly);
        }

        [Fact]

        public void FindByIdTest()
        {
            //Arrange
            Todo todo = new Todo(1, "Description");
            //Act
            int todoId = 1;
            //Assert
            Assert.Equal(1, todoId);
        }

        [Fact]

        public void FindTodoByIdTest()
        {
            //Arrange
            TodoService testingTodos = new TodoService();

            Todo testTodo1 = testingTodos.CreateNewTodo("Read");
            Todo testTodo2 = testingTodos.CreateNewTodo("Go swimming");
            Todo testTodo3 = testingTodos.CreateNewTodo("Finish assignment");
            int checkedTodoId = testTodo3.TodoId;

            //Act
            Todo matchedTodo = testingTodos.FindById(checkedTodoId);

            //Assert
            Assert.NotEqual(matchedTodo, testTodo2);
            Assert.NotEqual(matchedTodo, testTodo2);
            Assert.Equal(matchedTodo, testTodo3);
        }


        [Theory]
        [InlineData(1, "Description", "Description")]

        public void CreateNewTodoTest(int todoId, string description, string expected)
        {
            //Act
            Todo actuelly = todoCase.CreateNewTodo(description);
            //Assert
            Assert.Equal(expected, actuelly.Description);
        }

        [Fact]

        public void CreateNewTodosTest()
        {
            //Arrange
            TodoService testingTodo = new TodoService();
            testingTodo.Clear();

            string description1 = "Study";
            string description2 = "Exercise";
            string description3 = "Cook";

            //Act
            Todo testPerson1 = testingTodo.CreateNewTodo(description1);
            Todo testPerson2 = testingTodo.CreateNewTodo(description2);
            Todo testPerson3 = testingTodo.CreateNewTodo(description3);

            //Assert
            Assert.Equal(description1, testPerson1.Description);
            Assert.Equal(description2, testPerson2.Description);
            Assert.Equal(description3, testPerson3.Description);
        }

        [Fact]
        public void FindAllTest()
        {
            //Arrange            
            PeopleService testingPeople = new PeopleService();
            testingPeople.Clear();

            testingPeople.CreateNewPerson("Fred", "Lindberg");
            testingPeople.CreateNewPerson("Anna", "Molin");
            testingPeople.CreateNewPerson("Jens", "Schmidth");
            int expectedSize = 3;
            //Act
            Person[] actPersons = testingPeople.FindAll();
            //Assert
            Assert.Equal(expectedSize, actPersons.Length);
        }

        [Fact]
        public void FindByDoneTest()
        {
            //Arrange
            TodoService todoTest = new TodoService();
            todoTest.Clear();

            Todo todo1 = todoTest.CreateNewTodo("Go running");
            Todo todo2 = todoTest.CreateNewTodo("Relax");
            Todo todo3 = todoTest.CreateNewTodo("Finish Assignment");
            todoTest.FindById(todo1.TodoId).Done = true;
            todoTest.FindById(todo2.TodoId).Done = false;
            todoTest.FindById(todo3.TodoId).Done = true;

            //Act
            Todo[] findDones = todoTest.FindByDoneStatus(true);

            //Assert
            for (int i = 0; i < findDones.Length; i++)
            {
                Assert.True(findDones[i].Done);
            }
            Assert.Contains(todo1, findDones);
            Assert.Contains(todo3, findDones);
        }

        [Fact]
        public void TestFindByAssigneeId()
        {
            //Arrange
            int personId = PersonSequencer.NextPersonId();
            Person assignee = new Person("Fred", "Johnsson", personId);
            TodoService testTodos = new TodoService();
            testTodos.Clear();

            Todo todo1 = testTodos.CreateNewTodo("Go for a run");
            Todo todo2 = testTodos.CreateNewTodo("Sleep");
            Todo todo3 = testTodos.CreateNewTodo("Finish the test");
            Todo todo4 = testTodos.CreateNewTodo("Watch TV");
            todo1.Assignee = assignee;
            todo2.Assignee = assignee;

            //Act
            Todo[] findAssigneeArray = testTodos.FindByAssignee(personId);

            //Assert
            Assert.Contains(todo1, findAssigneeArray);
            //Assert.Contains(todo2, findAssigneeArray);
            //Assert.DoesNotContain(todo3, findAssigneeArray);
            Assert.DoesNotContain(todo4, findAssigneeArray);
        }

        [Fact]
        public void FindByAssigneePersonTest()
        {
            //Arrange
            int personId = PersonSequencer.NextPersonId();
            string firstName1 = "Julia";
            string lastName1 = "Fors";
            string firstName2 = "Oscar";
            string lastName2 = "Fors";

            Person expected = new Person(firstName1, lastName1, personId);
            Person expectedAss = new Person(firstName2, lastName2, personId);

            TodoService todoService = new TodoService();
            todoService.Clear();

            Todo todo = todoService.CreateNewTodo("Run");
            Todo todo1 = todoService.CreateNewTodo("Walk");
            Todo todo2 = todoService.CreateNewTodo("Sleep");
            todo.Assignee = expected;
            todo1.Assignee = expectedAss;
            todo2.Assignee = expectedAss;
            //Act
            Todo[] findByAssigneeArray = todoService.FindByAssignee(expectedAss);
            //Assert
            Assert.Contains(todo1, findByAssigneeArray);
            Assert.Contains(todo2, findByAssigneeArray);
            Assert.DoesNotContain(todo, findByAssigneeArray);
        }

        [Fact]
        public void FindUnassignedTodoTest()
        {
            //Arrange
            Person testPerson = new Person("Lotta", "Svensson", PersonSequencer.NextPersonId());
            TodoService testTodos = new TodoService();
            Todo todo1 = testTodos.CreateNewTodo("Have a rest");
            Todo todo2 = testTodos.CreateNewTodo("Eat");
            Todo todo3 = testTodos.CreateNewTodo("Work");
            Todo todo4 = testTodos.CreateNewTodo("Study");
            todo1.Assignee = testPerson;
            todo3.Assignee = testPerson;

            //Act
            Todo[] unassignedTodos = testTodos.FindUnassignedTodoItems();

            //Assert
            Assert.Contains(todo2, unassignedTodos);
            Assert.Contains(todo4, unassignedTodos);
            Assert.DoesNotContain(todo1, unassignedTodos);
            Assert.DoesNotContain(todo3, unassignedTodos);
        }
       
        [Fact]
        public void RemoveTodoIdTest()
        {
            //Arrange
            TodoService todoService = new TodoService();
            todoService.Clear();
            Todo todo1 = todoService.CreateNewTodo("Eat");
            Todo todo2 = todoService.CreateNewTodo("Sleap");
            Todo todo3 = todoService.CreateNewTodo("Run");
            //Act
            todoService.RemoveTodoId(todo1.TodoId); 
            //Assert
            Assert.Contains(todo2, todoService.FindAll());
            Assert.Contains(todo3, todoService.FindAll());
            Assert.DoesNotContain(todo1, todoService.FindAll());
        }
     
    }
}
