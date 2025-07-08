using Core.Models.AdminUser;
using Core.Models.Category;
using Core.Models.Search;
using Core.Models.Search.Params;
using Core.Models.Seeder;

namespace Core.Interfaces;

public interface IUserService
{
    Task<List<AdminUserItemModel>> GetAllUsersAsync();
    Task<SearchResult<AdminUserItemModel>> SearchUsersAsync(UserSearchModel model);
    Task<string> SeedAsync(SeedItemsModel model);
    Task<AdminUserItemModel> UpdateUsersAsync(AdminUserUpdateModel model);
    Task<AdminUserItemModel?> GetItemById(int id);
}
