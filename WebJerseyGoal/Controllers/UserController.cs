using AutoMapper;
using Core.Interfaces;
using Core.Models.Search.Params;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebJerseyGoal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService,
        IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var model = await userService.List();

            return Ok(model);
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchUsers([FromQuery] UserSearchModel model)
        {
            var result = await userService.SearchUsersAsync(model);
            return Ok(result);
        }

    }
}
