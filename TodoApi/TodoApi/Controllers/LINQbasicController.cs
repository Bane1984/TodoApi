using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Remotion.Linq.Clauses;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LINQbasicController : ControllerBase
    {

        public readonly TodoContext _context;
        public LINQbasicController(TodoContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        /// <summary>
        /// Uvod u LINQ-e.
        /// </summary>
        /// <returns></returns>
        [HttpGet("IntroToLinq")]
        public IEnumerable<int> IntroToLinq()
        {
            int[] niz = new int[5]{0, 1, 2, 5, 6};

            IEnumerable<int> upit =
                from num in niz
                where num >= 2
                select num;

            return upit;

        }

        /// <summary>
        /// Returns the dictionary.
        /// </summary>
        /// <returns></returns>
        [HttpGet("ReturnDictionary")]
        public Dictionary<int, string> ReturnDictionary()
        {
            Dictionary<int, string> a = new Dictionary<int, string>()
            {
                {1, "nana"},
                {2, "bane"},
                {5, "jole"},
                {3, "ana"},
                {4, "sonja"},
                {7, "sanja"},
                {6, "miki"},
                {8, "buci"},
                {0, "cici"}
            };

            Dictionary<int, string> recnik =
                (from b in a
                    where (b.Key % 2) != 0        //izmi iz recnika sve neparne kljuceve
                    select new
                    {   cKey = b.Key,
                        cValue = b.Value
                    }).ToDictionary(n => n.cKey, n => n.cValue);

            return recnik;

        }

        /// <summary>
        /// Exists the key.
        /// </summary>
        /// <param name="kljuc">The kljuc.</param>
        /// <returns></returns>
        [HttpGet("ExistKey/{kljuc}")]
        public string ExistKey(int kljuc)
        {
            Dictionary<int, string> recnik = new Dictionary<int, string>()
            {
                {50, "ja"},
                {0, "on"},
                {5, "mi"},
                {21, "vi"},
                {13, "oni"},
            };

            Dictionary<int, string> a = (from b in recnik
                where b.Key == kljuc
                select new
                {   cKey=b.Key,
                    cValue=b.Value
                }).ToDictionary(n => n.cKey, n => n.cValue);

            string test;
            if (a.TryGetValue(kljuc, out test))
            {
                return test;
            }

            return "Za uneseni kljuc nema vrijednosti";

        }

        /// <summary>
        /// Backs all names from list.
        /// </summary>
        /// <returns></returns>
        [HttpGet("BackAllNamesFromList")]
        public IEnumerable<string> BackAllNamesFromList()
        {
            List<string> a= new List<string>()
            {
                "bane", "ana", "jole", "nana"
            };

            IEnumerable<string> b = from c in a
                where c == a[1]
                select c;

                                         

            return b;
        }

        /// <summary>
        /// Vracanje vise parametara.
        /// </summary>
        /// <returns></returns>
        [HttpGet("VracanjeViseParametara")]
        public (int[], List<string>) VracanjeViseParametara()
        {
            List<int> a= new List<int>()
            {
                1, 2, 3, 4, 5
            };

            List<string> b = new List<string>()
            {
                "Pg", "Dg", "Nk"
            };

            int[] c = (from d in a
                where d > 3
                      orderby d descending 
                select d).ToArray();
            
            IEnumerable<string> m = from n in b
                where n == "Dg"
                select n;
            return (c, m.ToList());

        }

        /// <summary>
        /// Izlistaj cio json fajl.
        /// </summary>
        /// <returns></returns>
        [HttpGet("IzlistajJsonFajl")]
        public List<Contact> IzlistajJsonFajl()
        {
            IEnumerable<Contact> all = from svi in _context.Contacts.ToList()
                                        select svi;

            return all.ToList();
        }

        /// <summary>
        /// Pretrazi po imenu.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        [HttpGet("PretraziPoImenu")]
        public List<Contact> PretraziPoImenu(string name)
        {
            List<Contact> bane = new List<Contact>();
            string prazan = "Ne postoji uneseno ime u nasom JSON-u.";

            IEnumerable<Contact> ime = from svi in bane.ToList()
                where svi.ime == name
                                       select svi;

                return ime.ToList();

        }

        /// <summary>
        /// Vratiti kontant iz json fajla sa pretragom po imenu.
        /// </summary>
        /// <param name="a">a.</param>
        /// <returns></returns>
        [HttpGet("VratitiNekeKontakte/{a}")]
        public List<Contact> VratitiNekeKontakte(string a)
        {
            IEnumerable<Contact> contacts = from cont in _context.Contacts
                where cont.mjestoRodjenja == a || cont.mjestoRodjenja == "Panaoti"
                select cont;

            return contacts.ToList();
        }

        /// <summary>
        /// Opadajuce redjanje (testirati za Panaoti).
        /// </summary>
        /// <param name="a">a.</param>
        /// <returns></returns>
        [HttpGet("OpadajuceRedjanje/{a}")]
        public List<Contact> OpadajuceRedjanje(string a)
        {
            IEnumerable<Contact> contacts = from cont in _context.Contacts
                where cont.mjestoRodjenja == a
                      orderby cont.ime descending 
                select cont;

            return contacts.ToList();
        }

        /// <summary>
        /// Grupisanje po mjestu rodjenja.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GrupisanjeMjestuRodjenja")]
        public List<string> GrupisanjeMjestuRodjenja()
        {
            var groupCity = from city in _context.Contacts
                group city by city.mjestoRodjenja;

            List<string> list = new List<string>();
            List<string> list1 = new List<string>();
            foreach (var grupa in groupCity)
            {
                list.Add(grupa.Key);
                foreach (var name in grupa)
                {
                    list1.Add(name.ime);
                }
            }

            return list.ToList();
        }

        /// <summary>
        /// Joins Contacts i ContacLinqs ukoliko im je isti ID.
        /// </summary>
        /// <returns></returns>
        [HttpGet("JoinIskaz")]
        public IActionResult JoinIskaz()
        {
            var innerJoin = from cust in _context.Contacts
                join nameid in _context.ContactLinqs on cust.id equals nameid.id
                select new
                {
                    ImeKontakta = cust.ime,
                    ImeKontaktLinq = nameid.ime
                };

            return Ok(innerJoin);
        }

        /// <summary>
        /// Primjena lambda iskaza.
        /// </summary>
        /// <returns></returns>
        [HttpGet("ProsirenaMetoda")]
        public int[] ProsirenaMetoda()
        {
            int[] a = new int[]{4, 3, 5, 10, 23, 26};

            IEnumerable<int> parni = a.Where(num => num % 2 == 0);

            return parni.ToArray();

        }

        /// <summary>
        /// Lista imena koja pocinju sa slovom {a}.
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListaImena/{a}")]
        public string[] ListaImena(char a)
        {
            IEnumerable<string> imena = _context.Contacts.Select(name => name.ime).Where(name=>name.Contains(a));

            return imena.ToArray();
        }


    }
}