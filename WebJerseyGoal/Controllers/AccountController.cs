using AutoMapper;
using MailKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebJerseyGoal.Constants;
using WebJerseyGoal.DataBase.Entitties.Identity;
using WebJerseyGoal.Interfaces;
using WebJerseyGoal.Models.Account;
using WebJerseyGoal.Services;

namespace WebJerseyGoal.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController(IJwtTokenService jwtTokenService,
        UserManager<UserEntity> userManager,IMapper mapper,IImageService imageService) : ControllerBase
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



        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterModel model)
        {
            var user = mapper.Map<UserEntity>(model);
            user.Image = await imageService.SaveImageAsync(model.Avatar) ?? null;

            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }


    }
}
