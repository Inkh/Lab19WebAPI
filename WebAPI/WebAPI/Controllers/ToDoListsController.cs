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
    public class ToDoListsController : ControllerBase
    {
        private ToDoDbContext _context;

        public ToDoListsController(ToDoDbContext context)
        {
            _context = context;
        }

        //Get
        [HttpGet]
        public async Task<IEnumerable<ToDoList>> Get()
        {
            return await _context.ToDoList.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetToDoList([FromRoute]int id)
        {
            var toDoList = await _context.ToDoList.FirstOrDefaultAsync(t => t.ID == id);

            if (toDoList == null)
            {
                return NotFound();
            }
            return Ok(toDoList);
        }
        //Post
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ToDoList toDoList)
        {
            await _context.ToDoList.AddAsync(toDoList);
            await _context.SaveChangesAsync();

            return RedirectToAction("Get", new { id = toDoList.ID });
        }

        //Put
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]ToDoList toDoList)
        {
            var myToDoList = await _context.ToDoList.FirstOrDefaultAsync(t => t.ID == id);
            if (myToDoList != null)
            {
                _context.ToDoList.Update(toDoList);
            }
            else
            {
                await Post(toDoList);
            }
            return RedirectToAction("Get", new { id = toDoList.ID });
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _context.ToDoList.FirstOrDefaultAsync(t => t.ID == id);
            if (delete != null)
            {
                _context.ToDoList.Remove(delete);
            }
            return Ok();
        }
    }
}