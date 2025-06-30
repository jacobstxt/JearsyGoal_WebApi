using Core.Models.Account;

namespace Core.Interfaces
{
    public interface IAccountService
    {
        public Task<string> LoginByGoogle(string token);
        Task<List<UserItemModel>> List();
    }
}
