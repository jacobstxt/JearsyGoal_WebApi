using Core.Models.Cart;

namespace Core.Interfaces
{
    public interface ICartService
    {
        Task<long> CreateUpdate(CartCreateUpdateModel model,long userId);
    }
}
