using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;
using System;
using Microsoft.AspNetCore.Cors;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (_context.TodoItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.TodoItems.Add(new TodoItem { clientName = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<TodoItem>> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<TodoItem> GetById(long id)
        {

            var item = _context.TodoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        
        [HttpPost]
        public IActionResult Create(TodoItem item)
        {
            Console.WriteLine(item.clientName);
            Console.WriteLine(item.date);
            Console.WriteLine(item.paymentMethod);
            Console.WriteLine(item.productCode);
            Console.WriteLine(item.productDescription);
            Console.WriteLine(item.quantity);

            _context.TodoItems.Add(item);
            _context.SaveChanges();
            
            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }
    }
}