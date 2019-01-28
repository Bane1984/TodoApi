using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class ContactLinq
    {
        public static List<Contact> Contacts
        {
            get
            {
                var jsonString = File.ReadAllText("contactLinq.json"); //fajl contact smo generisali preko sajta https://www.mockaroo.com/ , fajl se mora smjestiti u C:\Program Files\IIS Express
                var list = JsonConvert.DeserializeObject<List<Contact>>(jsonString);
                return list;
            }

        }

        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public DateTime datumRodjenja { get; set; }
        public string mjestoRodjenja { get; set; }
        public string email { get; set; }
    }
}
