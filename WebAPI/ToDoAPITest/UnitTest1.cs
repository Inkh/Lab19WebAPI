using System;
using Xunit;
using WebAPI.Models;

namespace ToDoAPITest
{
    public class UnitTest1
    {
        /// <summary>
        /// Tests name getter on ToDo
        /// </summary>
        [Fact]
        public void ToDoCanGetNameTest()
        {
            ToDo taskOne = new ToDo();
            taskOne.Name = "Finish homework";
            taskOne.Completed = false;

            Assert.Equal("Finish homework", taskOne.Name);
        }

        /// <summary>
        /// Tests completed getter on ToDo
        /// </summary>
        [Fact]
        public void ToDoCanGetCompletedTest()
        {
            ToDo taskOne = new ToDo();
            taskOne.Name = "Finish homework";
            taskOne.Completed = false;

            Assert.True(taskOne.Completed == false);
        }

        /// <summary>
        /// Tests name setter on ToDo
        /// </summary>
        [Fact]
        public void ToDoCanSetNameTest()
        {
            ToDo taskOne = new ToDo();
            taskOne.Name = "Finish homework";
            taskOne.Completed = false;

            taskOne.Name = "Finish more homework";

            Assert.Equal("Finish more homework", taskOne.Name);
        }

        /// <summary>
        /// Tests completed setter on ToDo
        /// </summary>
        [Fact]
        public void ToDoCanSetCompletedTest()
        {
            ToDo taskOne = new ToDo();
            taskOne.Name = "Finish homework";
            taskOne.Completed = false;

            taskOne.Completed = true;

            Assert.True(taskOne.Completed);
        }

        /// <summary>
        /// Tests getters on TDL
        /// </summary>
        [Fact]
        public void ToDoListCanGetTest()
        {
            ToDoList myList = new ToDoList();
            myList.Name = "new list";

            Assert.Equal("new list", myList.Name);
        }

        /// <summary>
        /// Tests setters on TDL
        /// </summary>
        [Fact]
        public void ToDoListCanSetTest()
        {
            ToDoList myList = new ToDoList();
            myList.Name = "new list";

            myList.Name = "another name";
            Assert.Equal("another name", myList.Name);
        }
    }
}
