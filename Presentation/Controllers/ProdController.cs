
using Application.Contracts.Services;
using Application.DTO.ProductDTO.Request;
using Application.Dtos.CategoryDTO.Request;
using Application.Dtos.ProductDTO.Request;
using Infrastructure.Implementation.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProdController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProdController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("Stock/{productId}/{productName}")]
        //Check stock by Name and ID 
        public async Task<IActionResult> CheckStock([FromRoute]int productId) //note from abdelaziz
        {
            var request = new IsInStockRequest {ProductId = productId };
            var response= await _productService.IsInStockAsync(request);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPut("changeName")]
        //change product name
        public async Task <IActionResult> UpdateName([FromBody] ChangeProductNameRequest request)
        {
            if (!ModelState.IsValid)  // Added model validation
            {
                return BadRequest(ModelState);
            }
            var response=await _productService.ChangeProductNameAsync(request);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPut("ChangeDescription")]
        //update the description

        public async Task <IActionResult> ChangeDescription([FromBody] UpdateDescriptionRequest request)
        {
            if (!ModelState.IsValid)  // Added model validation
            {
                return BadRequest(ModelState);
            }
            var response= await _productService.UpdateDescriptionAsync(request);
            return StatusCode((int)response.StatusCode,response);

        }
        [HttpPost("createProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            if (!ModelState.IsValid)  // Added model validation
            {
                return BadRequest(ModelState);
            }

            var response = await _productService.CreateProductAsync(request);
            return StatusCode((int)response.StatusCode, response);

        }

        [HttpDelete("{Id}")] //route parameter
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var request = new RemoveProductRequest { ProductId = id };
            var response = await _productService.RemoveProductAsync(request);
            return StatusCode((int)response.StatusCode, response);

        }




    }
}
