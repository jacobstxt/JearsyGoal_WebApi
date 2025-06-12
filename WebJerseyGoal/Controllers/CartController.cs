using Core.Interfaces;
using Core.Models.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebJerseyGoal.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CartController(ICartService cartService) : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateUpdate([FromBody] CartCreateUpdateModel model)
        {
            var email = User.Claims.First().Value;

            return Ok();
        }
    }
}
