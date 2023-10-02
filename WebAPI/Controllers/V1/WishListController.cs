using Business.Abstract;
using Entities.DTOs.WishListDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;

namespace WebAPI.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class WishListController : ControllerBase
    {
        private readonly IWishListService _wishListService;

        public WishListController(IWishListService wishListService)
        {
            _wishListService = wishListService;
        }
        [MapToApiVersion("1.0")]
        [Authorize]
        [HttpPost("addwishlist/{productId}")]
        public IActionResult AddWishList([FromBody] WishListAddItemDTO wishListAddItemDTO)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var userId = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value;
            var user = Convert.ToInt32(userId);

            var result = _wishListService.AddWishList(user, wishListAddItemDTO);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [MapToApiVersion("1.0")]
        [HttpGet("userwishlist")]
        public IActionResult GetUserWishList()
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var userId = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value;
            var user = Convert.ToInt32(userId);
            var result = _wishListService.GetUserWishList(user);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

    }
}
