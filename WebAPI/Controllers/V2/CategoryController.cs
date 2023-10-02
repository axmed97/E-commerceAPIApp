using Business.Abstract;
using Entities.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.V2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [MapToApiVersion("2.0")]
        [HttpPost("addcategory")]
        public IActionResult AddCategory([FromBody]CategoryCreateDTO categoryCreateDTO) 
        {
            var result = _categoryService.AddCategory(categoryCreateDTO);

            if(result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [MapToApiVersion("2.0")]
        [HttpPut("updatecategory")]
        public IActionResult UpdateCategory([FromBody] CategoryUpdateDTO categoryUpdateDTO)
        {
            var result = _categoryService.UpdateCategory( categoryUpdateDTO);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [MapToApiVersion("2.0")]
        [HttpGet("homenavbarcategory")]
        public IActionResult CategoryHomeNavbar()
        {
            var result = _categoryService.GetNavbarCategories();
            if (result.Success)
                return Ok(result);
            
            return BadRequest(result);
        }
        [MapToApiVersion("2.0")]
        [HttpGet("featuredcategory")]
        public IActionResult CategoryFeatured()
        {
            var result = _categoryService.GetFeaturedCategories();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [MapToApiVersion("2.0")]
        [HttpGet("admincategories")]
        public IActionResult CategoryAdminList()
        {
            var result = _categoryService.CategoryAdminCategories();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [MapToApiVersion("2.0")]
        [HttpPut("changeStatuscategory/{categoryId}")]
        public IActionResult CategoryChangeStatus(int categoryId)
        {
            var result = _categoryService.CategoryChangeStatus(categoryId);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [MapToApiVersion("2.0")]
        [HttpDelete("deletecategory/{categoryId}")]
        public IActionResult CategoryDelete(int categoryId)
        {
            var result = _categoryService.DeleteCategory(categoryId);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
