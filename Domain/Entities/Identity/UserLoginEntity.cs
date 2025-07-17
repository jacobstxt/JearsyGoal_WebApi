using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity;

[Table("tbl_UserLogins")]
public class UserLoginEntity : IdentityUserLogin<long>
{
    public UserEntity User { get; set; }// = new();
}
