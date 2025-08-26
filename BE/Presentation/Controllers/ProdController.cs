using Application.Contracts.Repositories;
using Application.Contracts.Services;
using Application.DTO.ProductDTO.Request;
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

        [HttpGet("Stock")]
        //Check stock by Name and ID if 
        public async Task<IActionResult> CheckStock([FromQuery]Guid? productId, [FromQuery]string? productName)
        {
            var request = new IsInStockRequest { ProductName = productName, ProductId = productId };
            var response= await _productService.IsInStockAsync(request);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPut("change name")]
        //change product name
        public async Task <IActionResult> UpdateName([FromBody] ChangeProductNameRequest request)
        {
            var response=await _productService.ChangeProductNameAsync(request);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPut("Change description")]
        //update the description

        public async Task <IActionResult> ChangeDescription([FromBody] UpdateDiscriptionRequest request)
        {
            var response= await _productService.UpdateDiscriptionAsync(request);
            return StatusCode((int)response.StatusCode,response);

        }



        
    }
}
