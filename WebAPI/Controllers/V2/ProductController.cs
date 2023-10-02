using Business.Abstract;
using Entities.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.V2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [MapToApiVersion("2.0")]
        [HttpPost("createproduct")]
        public IActionResult CreateProduct([FromBody]ProductCreateDTO productCreateDTO)
        {
            var result = _productService.ProductCreate(productCreateDTO);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [MapToApiVersion("2.0")]
        [HttpPut("updatedproduct")]
        public IActionResult UpdatedProduct([FromBody] ProductUpdateDTO productUpdateDTO)
        {
            var result = _productService.ProductUpdate(productUpdateDTO);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [MapToApiVersion("2.0")]
        [HttpGet("productdetail/{productId}")]
        public IActionResult ProductDetail(int productId)
        {
            var result = _productService.ProductDetail(productId);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [MapToApiVersion("2.0")]
        [HttpGet("featuredproducts")]
        public IActionResult ProductFeatured()
        {
            var product = _productService.ProductFeaturedList();
            if (product.Success)
                return Ok(product);
            return BadRequest(product);
        }
        [MapToApiVersion("2.0")]
        [HttpGet("recentproducts")]
        public IActionResult ProductRecent()
        {
            var product = _productService.ProductRecentList();
            if (product.Success)
                return Ok(product);
            return BadRequest(product);
        }
        [MapToApiVersion("2.0")]
        [HttpGet("filterproducts")]
        public IActionResult ProductFilter([FromQuery]int categoryId, [FromQuery]int minPrice, [FromQuery] int maxPrice)
        {
            var product = _productService.ProductFilterList(categoryId, minPrice, maxPrice);
            if (product.Success)
                return Ok(product);
            return BadRequest(product);
        }
        [MapToApiVersion("2.0")]
        [HttpDelete("deleteproduct/{productId}")]
        public IActionResult ProductDelete(int productId)
        {
            var result = _productService.ProductDelete(productId);
            if(result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
