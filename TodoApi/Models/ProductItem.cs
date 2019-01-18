using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class ProductItem
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ime artikla je obavezno.")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
