using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Account
{
    public class ResetPasswordModel
    {
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Новий пароль")]
        [Required(ErrorMessage = "Вкажіть пароль")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Пароль має містити щонайменше 6 символів")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Підтвердіть пароль")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;
    }
}
