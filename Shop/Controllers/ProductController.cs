using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Shop.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductLogic _logic;

        public ProductsController( IProductLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {

          var products = _logic.ReadAllProduct();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {

           var product = _logic.ReadProduct(id);
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {

            _logic.CreateProduct(product);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
             _logic.UpdateProduct(product);

            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            _logic.DeleteProduct(id);

            return Ok();
        }
    }
}
