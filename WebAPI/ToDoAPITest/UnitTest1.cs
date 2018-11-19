using System;
using Xunit;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

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

        /// <summary>
        /// Tests creation on ToDo table
        /// </summary>
        [Fact]
        public async void ToDoCreateTest()
        {
            DbContextOptions<ToDoDbContext> options =
                new DbContextOptionsBuilder<ToDoDbContext>()
                .UseInMemoryDatabase("todoCreate")
                .Options;

            using (ToDoDbContext context = new ToDoDbContext(options))
            {

                //CREATE
                //Arrange
                ToDo taskOne = new ToDo();
                taskOne.Name = "Finish homework";
                taskOne.Completed = false;

                context.ToDos.Add(taskOne);
                context.SaveChanges();

                //READ
                var myTask = await context.ToDos.FirstOrDefaultAsync(t => t.Name == taskOne.Name);

                Assert.Equal("Finish homework", myTask.Name);
            }
        }

        /// <summary>
        /// Tests updating on ToDo table
        /// </summary>
        [Fact]
        public async void ToDoUpdateTest()
        {
            DbContextOptions<ToDoDbContext> options =
                new DbContextOptionsBuilder<ToDoDbContext>()
                .UseInMemoryDatabase("todoUpdate")
                .Options;

            using (ToDoDbContext context = new ToDoDbContext(options))
            {

                //CREATE
                //Arrange
                ToDo taskOne = new ToDo();
                taskOne.Name = "Finish homework";
                taskOne.Completed = false;

                context.ToDos.Add(taskOne);
                context.SaveChanges();

                //READ
                var myTask = await context.ToDos.FirstOrDefaultAsync(t => t.Name == taskOne.Name);

                myTask.Name = "New Name";
                context.Update(myTask);
                context.SaveChanges();

                var newTask = await context.ToDos.FirstOrDefaultAsync(t => t.Name == myTask.Name);

                Assert.Equal("New Name", newTask.Name);
            }
        }

        /// <summary>
        /// Tests deletion on todo table
        /// </summary>
        [Fact]
        public async void ToDoDeleteTest()
        {
            DbContextOptions<ToDoDbContext> options =
                new DbContextOptionsBuilder<ToDoDbContext>()
                .UseInMemoryDatabase("todoDelete")
                .Options;

            using (ToDoDbContext context = new ToDoDbContext(options))
            {

                //CREATE
                //Arrange
                ToDo taskOne = new ToDo();
                taskOne.Name = "Finish homework";
                taskOne.Completed = false;

                context.ToDos.Add(taskOne);
                context.SaveChanges();

                //READ
                var myTask = await context.ToDos.FirstOrDefaultAsync(t => t.Name == taskOne.Name);

                context.ToDos.Remove(myTask);
                context.SaveChanges();

                var deletedTask = await context.ToDos.FirstOrDefaultAsync(t => t.Name == myTask.Name);

                Assert.True(deletedTask == null);
            }
        }
    }
}
