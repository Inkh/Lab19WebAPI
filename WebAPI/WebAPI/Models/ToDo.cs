using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ToDo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
        public int ToDoListID { get; set; }

        //Nav prop
        public ToDoList ToDoList { get; set; }
    }
}
