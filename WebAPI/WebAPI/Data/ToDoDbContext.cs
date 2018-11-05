using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoList>().HasData(
                new ToDoList
                {
                    ID = 1,
                    Name = "Chores"
                },
                new ToDoList
                {
                    ID = 2,
                    Name = "Programming"
                }
            );
                
            modelBuilder.Entity<ToDo>().HasData(
                new ToDo
                {
                    ID = 1,
                    Name = "Vacuum the carpet",
                    Completed = false,
                    ToDoListID = 1
                },

                new ToDo
                {
                    ID = 2,
                    Name = "Mop the floors",
                    Completed = false,
                    ToDoListID = 1
                },
                new ToDo
                {
                    ID = 3,
                    Name = "Finish some labs",
                    Completed = true,
                    ToDoListID = 2
                }
            );
        }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<ToDoList> ToDoList { get; set; }
    }
}
