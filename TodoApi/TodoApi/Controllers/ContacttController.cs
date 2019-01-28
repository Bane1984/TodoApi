using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContacttController : ControllerBase
    {
        static List<Contact> a = new List<Contact> ()
        {
            new Contact(){id = 1, ime= "Ana", prezime = "Vujovic", datumRodjenja = new DateTime(2018, 10, 15), mjestoRodjenja = "Pg", email = "ana@gmail.com"},
            new Contact(){id = 2, ime= "Bane", prezime = "Vujovic", datumRodjenja = new DateTime(2018, 11, 23), mjestoRodjenja = "Dg", email = "bane@gmail.com"},
            new Contact(){id = 3, ime= "Jole", prezime = "Vujovic", datumRodjenja = new DateTime(2018, 12, 8), mjestoRodjenja = "Nk", email = "jole@gmail.com"}
        };

        [HttpGet]
        public List<Contact> GetA()
        {
            return a;
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> GetA(int id)
        {
            int m = id - 1;
 
            if (a == null)
            {
                return NotFound();
            }

            return a[m];
        }

        //[HttpPut]
        //public IEnumerable<Contact> PutContact(int id, Contact a)
        //{

        //    return ;
        //}
    }
}