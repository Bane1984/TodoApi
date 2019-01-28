using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }
        
         
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactLinq> ContactLinqs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var jsonString = File.ReadAllText("contact.json");
            var list = JsonConvert.DeserializeObject<List<Contact>>(jsonString);
            modelBuilder.Entity<Contact>().HasData(list);
            var jsonStringLinq = File.ReadAllText("contactLinq.json");
            var listLinq = JsonConvert.DeserializeObject<List<ContactLinq>>(jsonStringLinq);
            modelBuilder.Entity<ContactLinq>().HasData(listLinq);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    var jsonStringLinq = File.ReadAllText("contactLinq.json");
        //    var listLinq = JsonConvert.DeserializeObject<List<ContactLinq>>(jsonStringLinq);
        //    modelBuilder.Entity<ContactLinq>().HasData(listLinq);
        //}
    }
}
