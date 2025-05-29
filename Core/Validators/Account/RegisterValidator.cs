using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Domain.Entitties.Identity;
using Core.Models.Account;

namespace WebJerseyGoal.Validators.Account
{
    public class RegisterValidator: AbstractValidator<RegisterModel>
    {
        public RegisterValidator(UserManager<UserEntity> userManager)
        {
            RuleFor(x => x.Name)
              .NotEmpty().WithMessage("Name is required");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname is required");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format")
                .MustAsync(async (email, cancellation) =>
                {
                    var user = await userManager.FindByEmailAsync(email);
                    return user == null;
                }).WithMessage("Email already exists");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Passwords do not match");
        }
    }
}
