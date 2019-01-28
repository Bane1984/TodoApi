using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactLinqController : ControllerBase
    {
        public readonly TodoContext _context;
        public ContactLinqController(TodoContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
    }
}