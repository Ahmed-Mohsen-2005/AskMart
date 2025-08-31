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
    public class CategController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] AddCategoryRequest request)
        {
            if (!ModelState.IsValid)  // Added model validation
            {
                return BadRequest(ModelState);
            }

            var response = await _categoryService.AddCategoryAsync(request);
            return StatusCode((int)response.StatusCode, response);

        }

        [HttpPut]

        public async Task<IActionResult> UpdateCategoryName([FromBody] ChangeCategoryNameRequest request)
        {
            if (!ModelState.IsValid)  // Added model validation
            {
                return BadRequest(ModelState);
            }

            var response = await _categoryService.ChangeCategoryNameAsync(request);
            return StatusCode((int)response.StatusCode, response);

        }

        [HttpDelete("{Id}")] //route parameter
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var request = new RemoveCategoryRequest { CategoryId = id };
            var response = await _categoryService.RemoveCategoryAsync(request);
            return StatusCode((int)response.StatusCode, response);

        }

    }
}