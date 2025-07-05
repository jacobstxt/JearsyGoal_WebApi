using Core.Models.Account;
using Core.Models.Search;
using Core.Models.Search.Params;

namespace Core.Interfaces
{
    public interface IUserService
    {
        Task<List<UserItemModel>> List();
        Task<SearchResult<UserItemModel>> SearchUsersAsync(UserSearchModel model);
    }
}
