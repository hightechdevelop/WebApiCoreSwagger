﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("/api/[controller]")]                  // атрибут [Route] для определения маршрута непосредственно в контроллере - принцип маршрутизации на основе атрибутов
    public class ProductsController : Controller
    {
        private static List<Product> products = new List<Product>(new[] {
            new Product() { Id = 1, Name = "Notebook", Price = 1000000},
            new Product() { Id = 2, Name = "Car", Price = 2000000},
            new Product() { Id = 3, Name = "Apple", Price = 30}, 
        });

        [HttpGet]
        public IEnumerable<Product> Get() => products;

        [HttpGet("{id}")]                          // параметр для маршрутизации
        public IActionResult Get(int id)
        { 
            var product = products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            { 
                return NotFound();                // возвращает ошибку 404
            }

            return Ok(product);                   // возвращает объект преобразованный в JSON  и ответ статус 200
        }

        [HttpDelete("{id}")]                          
        public IActionResult Delete(int id)
        {
            var product = products.SingleOrDefault(p => p.Id == id);

            if (product != null)
            {
                products.Remove(product);
            }
            else {
                return NotFound();  
            }

            return Ok( new { Message =  "deleted successfully" });                    
        }

        public int NextProductId => products.Count() == 0 ? 1 : products.Max(x => x.Id) +1;

        [HttpGet("GetNextProductId")]    //   /api/GetNextProductId/
        public int GetNextProductId()
        {
            return NextProductId;
        }

        [HttpPost]
        public IActionResult Post(Product product)

        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }

            product.Id = NextProductId;
            products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPost("AddProduct")]
        public IActionResult PostBody([FromBody] Product product) =>
            Post(product);

        [HttpPut]
        public IActionResult Put(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var storeProduct = products.SingleOrDefault(p => p.Id == product.Id);
            if (storeProduct == null)
                return NotFound();
            storeProduct.Name = product.Name;
            storeProduct.Price = product.Price;
            return Ok(storeProduct);
        }

        [HttpPut("UpdateProduct")]
        public IActionResult PutBody([FromBody] Product product) => Put(product);

    }
}
