﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Interfaces;
using Core.Models.Cart;
using Domain;
using Domain.Entitties;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class CartService(AppDbJerseyGoalContext jerseyContext
        ,IAuthService authService, IMapper mapper) : ICartService
    {
        public async Task CreateUpdate(CartCreateUpdateModel model)
        {
            var userId = await authService.GetUserId();
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
                jerseyContext.Carts.Add(entity);
            }
            await jerseyContext.SaveChangesAsync();
            //return entity.ProductId;
        }

        public async Task Delete(long productId)
        {
            var userId = await authService.GetUserId();
            var item = await jerseyContext.Carts
                .SingleOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId);
            if (item != null)
            {
                jerseyContext.Carts.Remove(item);
                await jerseyContext.SaveChangesAsync();
            }
        }

        public async Task<List<CartItemModel>> GetCartItems()
        {
            var userId = await authService.GetUserId();

            var items = await jerseyContext.Carts
                .Where(x => x.UserId == userId)
                .ProjectTo<CartItemModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            return items;
        }

    }
}
