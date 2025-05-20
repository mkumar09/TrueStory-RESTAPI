using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestApi.Models;
using RestApi.Service;
using System.Text.Json;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController( IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("product")]
        public async Task<IActionResult> getProducts([FromQuery] string? search, [FromQuery] int page = 1,
    [FromQuery] int pageSize = 10)
        {
            try
            {
                if (page < 1 || pageSize < 1)
                    throw new Exception("Page and pagesize must be greater than 0.");
                return Ok(await _productService.getProductsByNameandPage(search, page, pageSize));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost]
        [Route("product")]
        public async Task<IActionResult> addProduct([FromBody]Product product)
        {
            try
            {
                return Ok(await _productService.addProduct(product));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("product/{id}")]
        public async Task<IActionResult> deleteProduct(String id)
        {
            try
            {
                return Ok(await _productService.deleteProduct(id));
            }
            catch ( HttpRequestException ex )
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
