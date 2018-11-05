using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private ToDoDbContext _context;

        public ToDoController(ToDoDbContext context)
        {
            _context = context;
        }

        //Get
        [HttpGet]
        public async Task<IEnumerable<ToDo>> Get()
        {
            return await _context.ToDos.ToListAsync();
        }

        //Post

        //Put

        //Delete
    }
}