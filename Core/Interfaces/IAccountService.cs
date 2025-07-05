using Core.Models.Account;
using Core.Models.Search;
using Core.Models.Search.Params;

namespace Core.Interfaces
{
    public interface IAccountService
    {
        public Task<string> LoginByGoogle(string token);
    }
}
