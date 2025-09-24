using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private static List<Product> _products = new();

        // GET: api/values
        [HttpGet]
        public IEnumerable<Product> GetItemList()
        {
            return _products;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Product? GetItem(int id)
        {
            return _products.Find(x => x.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, Product product)
        {
            var index = _products.FindIndex(x => x.Id == id);

            if (index == -1)
            {
                return;
            }

            //_products[index] = product;

            _products[index].Name = product.Name;
            _products[index].Price = product.Price;
            _products[index].Category = product.Category;

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var index = _products.FindIndex(x => x.Id == id);

            if (index == -1)
            {
                return;
            }

            _products.RemoveAt(index);


            //Sorting remaining elements of Product list
            int counter = 1;
            for (int i = 0; i < _products.Count; i++)
            {
                _products[counter - 1].Id = counter;
                counter++;
            }

        }

    }

}

