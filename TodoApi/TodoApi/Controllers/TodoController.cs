using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/todo")]
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
                _context.TodoItems.Add(new TodoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }
        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }
        /// <summary>
        /// Uzimanje Todo objekata sa odredjenim Id-em ukoliko postoji pod tim Id-em, ukoliko ne NotFound slijedi.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItems(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // POST: api/Todo
        /// <summary>
        /// Kreiranje Todo objekata.
        /// </summary>
        /// <remarks>
        /// Jednostavan zahtjev:
        ///     POST /Todo
        ///     {
        ///       "id": 1,
        ///       "name": "Item1",
        ///       "isComplete": true
        ///     }
        /// </remarks>
        /// <param name="item"></param> //obrati paznju naziv parametra se mora poklapati sa imenom paramtra u PostTodoItem metodi ispod
        /// <returns>Novokreirani Todo objekat.</returns>
        /// <response code="201">Vrace se novokreirani objekat.</response>
        /// <response code="400">Ako je objekat null.</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<TodoItem> Create(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        /// <summary>
        /// Update objekata ukoliko je id dobar ukoliko ne BadRequest.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Brisanje odredjnih Todo stvari.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.TodoItems.Find(id);

            if (todo == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todo);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
    