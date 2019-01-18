using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly ProductContext _product;

        public ProductController(ProductContext product)
        {
            _product = product;
            if (_product.ProductItems.Count()==0)
            {
                _product.ProductItems.Add(new ProductItem {Name = "Cokolada", Description = "95% kakao"});
                _product.SaveChanges();
            }

        }
        // GET: api/product/products
        //[Route(("products"))] radi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductItem>>> GetProductItems()
        {
            return await _product.ProductItems.ToListAsync();
        }

        // GET: api/product/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductItem>> GetProductItems(int id)
        {
            var prodItem = await _product.ProductItems.FindAsync(id);

            if (prodItem == null)
            {
                return NotFound();
            }

            return prodItem;
        }

    }
}
