using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoIt.Data;

namespace TodoIt.DataTest
{
    public class TodoSequencerTest 
    {
        
        [Fact]
        public void TodoSequencerMethodTest()
        {
            //If it is not empty
            Assert.NotEqual(0, TodoSequencer.NextTodoId());
            //reset it
            TodoSequencer.Reset();
            //then look for id 1, 2, 3
            Assert.Equal(1, TodoSequencer.NextTodoId());
            Assert.Equal(2, TodoSequencer.NextTodoId());
            Assert.Equal(3, TodoSequencer.NextTodoId());
        }
        
        [Fact]

        public void NextTodoIdTest()
        {
            TodoSequencer.Reset();
            //Arrange
            int expectedId1 = 1;
            int expectedId2 = 2;
            int todoId1;
            int todoId2;

            //Act
            todoId1 = TodoSequencer.NextTodoId();
            todoId2 = TodoSequencer.NextTodoId();

            //Assert
            Assert.Equal(expectedId1, todoId1);
            Assert.Equal(expectedId2, todoId2);
        }

        [Fact]
        public void TodoSequencerResetIdTest()
        {
            //Arrange
            int exp = 0;
            TodoSequencer.TodoId = 4;
            //Act
            TodoSequencer.Reset();
            //Assert
            Assert.Equal(exp, TodoSequencer.TodoId);
        }
    }
}
