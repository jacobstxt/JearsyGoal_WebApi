using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Domain.Entitties.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Core.Services
{
    public class AuthService(IHttpContextAccessor httpContextAccessor,
        UserManager<UserEntity> userManager): IAuthService
    {
        public async Task<long> GetUserId()
        {
           var email = httpContextAccessor.HttpContext?.User?.Claims.First().Value;
            if(string.IsNullOrEmpty(email))
                throw new UnauthorizedAccessException("User is not authenticated.");
            var user = await userManager.FindByEmailAsync(email);

            return user.Id;
        }


    }
}
