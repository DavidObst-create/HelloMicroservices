using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsService.Models;

namespace HelloMicroservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Product1", Price = 10.0M },
            new Product { Id = 2, Name = "Product2", Price = 20.0M }
        };

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return Products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = Products.Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }
    }
}
