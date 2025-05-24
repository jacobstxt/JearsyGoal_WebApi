using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebJerseyGoal.DataBase.Entitties.Identity;
using WebJerseyGoal.Interfaces;
using WebJerseyGoal.Models.Account;
using WebJerseyGoal.Services;

namespace WebJerseyGoal.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController(IJwtTokenService jwtTokenService,
        UserManager<UserEntity> userManager) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
            {
                return Unauthorized("Invalid email or password");
            }
            var token = await jwtTokenService.CreateTokenAsync(user);
            return Ok(new { Token = token });
        }



        //[HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody] RegisterModel model)
        //{
        //    var user = new UserEntity
        //    {
        //        UserName = model.Username,
        //        Email = model.Email,
        //        FirstName = model.FirstName,
        //        LastName = model.LastName
        //    };
        //    var result = await userManager.CreateAsync(user, model.Password);
        //    if (!result.Succeeded)
        //    {
        //        return BadRequest(result.Errors);
        //    }
        //    return Ok();
        //}

    }
}
