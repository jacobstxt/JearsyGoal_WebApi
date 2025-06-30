using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using Core.Interfaces;
using Core.Models.Account;
using Core.SMTP;
using Domain.Entitties.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Core.Services
{
    public class ResetPasswordService(UserManager<UserEntity> userManager,
        ISMTPService sMTPService,
        IConfiguration configuration) : IResetPasswordService
    {
        public async Task ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            var user = await userManager.FindByEmailAsync(forgotPasswordModel.Email);
            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            var frontendUrl = configuration["FrontendUrl"];
            var resetUrl = $"{frontendUrl}/reset-password?email={Uri.EscapeDataString(user.Email)}&token={Uri.EscapeDataString(token)}";
           
            MessageModel msgEmail = new MessageModel
            {
                Body = $"Для скидання паролю перейдіть за посиланням: <a href='{resetUrl}'>Скинути пароль</a>",
                Subject = $"Скидання паролю",
                To = forgotPasswordModel.Email
            };
            await sMTPService.SendEmailAsync(msgEmail);
        }

        public async Task ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            var user = await userManager.FindByEmailAsync(resetPasswordModel.Email);

            if (user == null)
                throw new Exception("Користувача не знайдено.");

            if (resetPasswordModel.Password != resetPasswordModel.ConfirmPassword)
            {
                throw new Exception("Паролі не співпадають.");
            }
            var result = await userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
        }


    }
}
