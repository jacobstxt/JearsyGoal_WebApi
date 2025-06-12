using Core.Interfaces;
using Core.Models.Cart;
using Domain;
using Domain.Entitties;

namespace Core.Services
{
    public class CartService(AppDbJerseyGoalContext jerseyContext) : ICartService
    {
        public async Task<long> CreateUpdate(CartCreateUpdateModel model, long userId)
        {
            var entity = jerseyContext.Carts
                .SingleOrDefault(c => c.ProductId == model.ProductId && c.UserId == userId);
            if (entity != null)
                entity.Quantity = model.Quantity;
            else
            {
                entity = new CartEntity
                {
                    ProductId = model.ProductId,
                    UserId = userId,
                    Quantity = model.Quantity
                };        
            }
            jerseyContext.Carts.Update(entity);
            await jerseyContext.SaveChangesAsync();
            return entity.ProductId;
        }
    }
}
