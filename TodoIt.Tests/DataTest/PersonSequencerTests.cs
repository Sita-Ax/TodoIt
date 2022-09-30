using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoIt.Data;

namespace TodoIt.DataTest
{
    public class PersonSequencerTests 
    {
        /*
        [Fact]
        public void PersonSequencerClassTest()
        {
            // Arrange
            PersonSequencer sequencer = new PersonSequencer();
            int personId = 1;

            // Act
            bool act = personId.CompareTo(0) == 0;
            bool act1 = personId.CompareTo(1) == 0;
            bool act2 = sequencer.Equals(personId);
            bool act3 = sequencer.GetType().Equals(personId);
            // Assert        
            Assert.False(act);
            Assert.True(act1);
            Assert.False(act2);
            Assert.False(act3);
        }
        */

        [Fact]
        public void ResetPersonIdTest()
        {
            //Arrange
            PersonSequencer.Reset();
            int expected = 0;
            int actual;
            actual = PersonSequencer.PersonId;

            //Act
            PersonSequencer.PersonId = 5;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NextPersonIdTest()
        {
            //Arrange
            int nextId1 = 1;
            int nextId2 = 2;
            int personId1;
            int personId2;

            //Act
            personId1 = PersonSequencer.NextPersonId();
            personId2 = PersonSequencer.NextPersonId();

            //Assert
            Assert.Equal(nextId1, personId1);
            Assert.Equal(nextId2, personId2);
        }

    }
}
