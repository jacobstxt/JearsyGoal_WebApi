using Core.Models.Cart;

namespace Core.Interfaces
{
    public interface ICartService
    {
        Task CreateUpdate(CartCreateUpdateModel model);
        Task Delete(long productId);
    }
}
