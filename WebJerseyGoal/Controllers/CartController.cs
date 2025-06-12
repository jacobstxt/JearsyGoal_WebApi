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
        public async Task<IActionResult> CreateUpdate([FromBody] CartCreateUpdateModel model)
        {
            await cartService.CreateUpdate(model);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var model = await cartService.GetCartItems();
            return Ok(model);
        }
    }
}
