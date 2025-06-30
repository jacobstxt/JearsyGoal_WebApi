using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Account;

namespace Core.Interfaces
{
    public interface IResetPasswordService
    {
        public Task ForgotPassword(ForgotPasswordModel forgotPasswordModel);
        public Task ResetPassword(ResetPasswordModel resetPasswordModel);

    }
}
