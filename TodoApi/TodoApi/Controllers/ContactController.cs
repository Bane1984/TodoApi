using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public readonly TodoContext _context;
        public ContactController(TodoContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContacts(int id)
        {
            var contactId = await _context.Contacts.FindAsync(id);
            if (contactId == null)
            {
                return NotFound();
            }

            return contactId;

        }

        //[HttpGet("{ime}")]
        //public  ActionResult<IEnumerable<Contact>> GetContacts(string name)
        //{
        //    var ime = _context.Contacts.Include(c=>c.name);
        //    if (ime == null)
        //    {
        //        return BadRequest();
        //    }

        //    return ime;

        //}

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<Contact> Create(Contact item)
        {

            _context.Contacts.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, Contact inputModel)
        {
            if (id != inputModel.id)
            {
                return BadRequest();
            }

            _context.Entry(inputModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contact);
            _context.SaveChanges();

            return NoContent();
        }
    }
}