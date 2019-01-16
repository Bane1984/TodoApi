using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        [Required]                          // za ovaj atribut se dodaje System.ComponentModel.DataAnnotations
        public string Name { get; set; }
        [DefaultValue(false)]               // za ovaj atribut se dodaje System.ComponentModel
        public bool IsComplete { get; set; }
    }
}
