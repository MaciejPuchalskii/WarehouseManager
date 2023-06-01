using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseManager.Server.Repositories;
using WarehouseManager.Shared;

namespace WarehouseManager.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        { _productRepository = productRepository;}

        [HttpGet]

        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            return Ok(await (_productRepository.GetAllProducts()));
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetSingleProduct(int id)
        {
            return Ok(_productRepository.GetProductById(id));
        }
        [HttpPost]
        public ActionResult<Product> CreateNewProduct(Product product)
        {
            return Ok(_productRepository.CreateNewProduct(product));
        }
        [HttpGet("search/{searchText}")]
        public ActionResult<List<Product>> SearchProducts(string searchText)
        { return Ok(_productRepository.SearchProduct(searchText));}

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            return Ok(_productRepository.DeleteProduct(id));    
        }
    }
}
