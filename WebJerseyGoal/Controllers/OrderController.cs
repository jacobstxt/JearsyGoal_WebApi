using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebJerseyGoal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        [Authorize]
        [HttpGet("list")]
        public async Task<IActionResult> GetUserOrders()
        {
            var model = await orderService.GetOrdersAsync();

            return Ok(model);
        }
    }
}
