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
            modelBuilder.Entity<ToDo>().HasData(
                new ToDo
                {
                    ID = 1,
                    Name = "Vacuum the carpet",
                    Completed = false
                },

                new ToDo
                {
                    ID = 2,
                    Name = "Mop the floors",
                    Completed = false
                },
                new ToDo
                {
                    ID = 3,
                    Name = "Finish some labs",
                    Completed = true
                }
            );
        }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<ToDoList> ToDoList { get; set; }
    }
}
