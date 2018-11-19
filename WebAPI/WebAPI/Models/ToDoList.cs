﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ToDoList
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //Nav props
        public ICollection<ToDo> ToDos { get; set; }
    }
}
