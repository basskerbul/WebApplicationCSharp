using Microsoft.AspNetCore.Mvc;
using WebApplicationCSharp.Models;

namespace WebApplicationCSharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet("get_product")]
        public IActionResult GetProducts()
        {
            try
            {
                using (var context = new ProductContext())
                {
                    var products = context.Products.Select(x => new Product 
                    { 
                        Id = x.Id, 
                        Name = x.Name,
                        Description = x.Description
                    });
                    return Ok(products);
                }
            }
            catch { return StatusCode(500); }
        }

        [HttpPost("put_product")]
        public IActionResult PutProducts([FromQuery] string name, string description, int group_id, int price)
        {
            try
            {
                using (var context = new ProductContext())
                {
                    if(!context.Products.Any(x => x.Name.ToLower().Equals(name.ToLower())))
                    {
                        context.Add(new Product
                        {
                            Name = name,
                            Description = description,
                            Price = price,
                            ProductGroupID = group_id
                        });
                        return Ok();
                    } else
                    {
                        return StatusCode(409);
                    }
                }
            }
            catch { return StatusCode(500); }
        }

        [HttpPut("put_product")]
        public IActionResult PutProduct([FromQuery] int price)
        {
            try
            {
                using (var context = new ProductContext())
                {
                    var products = context.Products.Select(x => x.Price = price);
                    return Ok(products);
                }
            }
            catch { return StatusCode(500); }
        }

        [HttpDelete("delete_product")]
        public IActionResult DeleteProducts()
        {
            try
            {
                if (!context.Products.Any(x => x.ID.Equals(ID)))
                {
                    context.Delete(ID);
                    return Ok();
                }
                else
                {
                    return StatusCode(409);
                }
            }
            catch { return StatusCode(500); }
        }
    }
}
