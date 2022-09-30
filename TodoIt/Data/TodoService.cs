using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoIt.Models;

namespace TodoIt.Data
{
    public class TodoService
    {
        //An array 
        private static Todo[] todoArray = new Todo[0];

        public Todo[] TodoArray
        {
            get
            {
                return todoArray;
            }
            set
            {
                todoArray = value;
            }
        }

        //This will return all things inside the todo array
        public int Size()
        {
            return todoArray.Length;
        }

        //To find all todo
        public Todo[] FindAll()
        {
            return todoArray;
        }
        //Looked for the todos Id and compare to the Id I want to find.
        public Todo? FindById(int todoId)
        {
           foreach (Todo todoItem in todoArray)
            {
                if(todoItem.TodoId == todoId)
                {
                    return todoItem;
                }
            }
            return null;
        }

        //Method to create a new todo and send in parameters inside this that belongs to the todo

        public Todo CreateNewTodo(string description)
        {
            //create a new todo, make uniq Id by call the NextTodoId method and give the description
            Todo newTodo = new Todo(TodoSequencer.NextTodoId(), description);
            //Resize my array
            Array.Resize<Todo>(ref todoArray, todoArray.Length + 1);
            //Put my new todo into my resized array
            todoArray[todoArray.Length - 1] = newTodo;
            //Get the new todo
            return newTodo;
        }

        public void Clear()
        {
            todoArray = new Todo[0];
        }

        //Compare the todoArray index that has the same status
        public Todo[]? FindByDoneStatus(bool doneStatus)
        {
            Todo[] todos = new Todo[0];
            foreach (Todo todoItem in todoArray)
            {
                if (todoItem.Done == doneStatus)
                {
                    Array.Resize(ref todos, todos.Length + 1);
                    todos[todos.Length - 1] = todoItem;
                }
            }
            return todos;
        }

        //Returns array that has assignee with personId as parameter
        public Todo[] FindByAssignee(int personId)
        {
            Todo[] todos = new Todo[0];
            foreach (Todo todoItem in todoArray) //look on the hole array 
            {
                if(todoItem.Assignee != null) //if it´s items that is not assignee 
                {
                    if(todoItem.Assignee.PersonId == personId)//pick out the todoItems that assignee the personId
                    {
                        Array.Resize(ref todos, todos.Length + 1);  //resize the array to get room for this
                        todos[todos.Length - 1] = todoItem;
                    }
                }
            }
           return todos;    //return the new array
        }

        //Returns the todos that belongs to assignee person as parameter
        public Todo[] FindByAssignee(Person assignee)   
        {
            Todo[] todos = new Todo[0];

            foreach (Todo todoItem in todoArray)
            {
                if(todoItem.Assignee == assignee)
                {
                    Array.Resize(ref todos, todos.Length + 1);  //resize the array to get room for this
                    todos[todos.Length - 1] = todoItem;
                }
            }
            return todos;
        }

        //This will return the array of todos that has no assignee
        public Todo[] FindUnassignedTodoItems()
        {
            Todo[] todos = new Todo[0];

            foreach (Todo todoItem in todoArray)
            {
                if (todoItem.Assignee == null)
                {
                    Array.Resize(ref todos, todos.Length + 1);  //resize the array to get room for this
                    todos[todos.Length - 1] = todoItem;
                }
            }
            return todos;
        }

        public void RemoveTodoId(int personId)
        {
            for (int i = 0; i < todoArray.Length; i++)    //look in to personarray
            {
                if (todoArray[i].TodoId == personId)//inside array I look at the todo and the id. 
                {
                    for (int offset = i + 1; offset < todoArray.Length; offset++, i++)
                    {
                        todoArray[i] = todoArray[offset];
                    }
                    Array.Resize(ref todoArray, todoArray.Length -1);
                    break;
                }
            }
        }
      
    }
}
