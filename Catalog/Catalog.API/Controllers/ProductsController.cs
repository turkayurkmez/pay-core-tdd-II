using Catalog.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet("{name}")]
        public IActionResult Search(string name)
        {

            var products = productService.SearchProductsByName(name);

            //var filtered = products.Where(p => p.Name.Contains(name));

            return Ok(products);
        }
    }
}
