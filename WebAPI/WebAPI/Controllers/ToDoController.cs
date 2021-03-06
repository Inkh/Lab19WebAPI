﻿using System;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetToDo([FromRoute]int id)
        {
            var toDo = await _context.ToDos.FirstOrDefaultAsync(s => s.ID == id);

            if (toDo == null)
            {
                return NotFound();
            }
            return Ok(toDo);
        }

        //Post
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ToDo toDo)
        {
            await _context.ToDos.AddAsync(toDo);
            await _context.SaveChangesAsync();

            return RedirectToAction("Get", new { id = toDo.ID });
        }

        //Put
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]ToDo toDo)
        {
            var myToDo = await _context.ToDos.FirstOrDefaultAsync(t => t.ID == id);
            if (myToDo != null)
            {
                _context.ToDos.Update(toDo);
            }
            else
            {
                await Post(toDo);
            }
            return RedirectToAction("Get", new { id = toDo.ID });
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _context.ToDos.FirstOrDefaultAsync(t => t.ID == id);
            if (delete != null)
            {
                _context.ToDos.Remove(delete);
            }
            return Ok();
        }
    }
}