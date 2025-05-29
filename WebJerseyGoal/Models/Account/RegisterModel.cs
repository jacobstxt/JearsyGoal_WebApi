using System.ComponentModel.DataAnnotations;

namespace WebJerseyGoal.Models.Account
{
    public class RegisterModel
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public string? AvatarUrlPreview { get; set; } = string.Empty;
        public IFormFile? Avatar { get; set; }
    }
}
