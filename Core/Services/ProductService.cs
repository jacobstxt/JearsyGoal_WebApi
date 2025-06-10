using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Interfaces;
using Core.Models.Product;
using Domain;
using Domain.Entitties;
using Domain.Entitties.Identity;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class ProductService(IMapper mapper, AppDbJerseyGoalContext context, IImageService imageService) : IProductService
    {
        public async Task<ProductItemModel> GetById(int id)
        {
            var model = await context.Products
                .Where(x => x.Id == id)
                .ProjectTo<ProductItemModel>(mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();

            return model;
        }

        public async Task<List<ProductItemModel>> GetBySlug(string slug)
        {
            var model = await context.Products
                .Where(x => x.Slug == slug)
                .ProjectTo<ProductItemModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            return model;
        }

        public async Task<List<ProductItemModel>> List()
        {
            var model = await context.Products
                .ProjectTo<ProductItemModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            return model;
        }


        public async Task<ProductEntity> Create(ProductCreateModel model)
        {
            var entity = mapper.Map<ProductEntity>(model);
            context.Products.Add(entity);
            await context.SaveChangesAsync();
            foreach (var ingId in model.IngredientIds!)
            {
                var productIngredient = new ProductIngredientEntity
                {
                    ProductId = entity.Id,
                    IngredientId = ingId
                };
                context.ProductIngredients.Add(productIngredient);
            }
            await context.SaveChangesAsync();


            for (short i = 0; i < model.ImageFiles!.Count; i++)
            {
                try
                {
                    var productImage = new ProductImageEntity
                    {
                        ProductId = entity.Id,
                        Name = await imageService.SaveImageAsync(model.ImageFiles[i]),
                        Priority = i
                    };
                    context.ProductImages.Add(productImage);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Json Parse Data for PRODUCT IMAGE", ex.Message);
                }
            }
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<ProductIngridientModel>> GetIngredientsAsync()
        {
            var ingredients = await context.Ingredients
                .ProjectTo<ProductIngridientModel>(mapper.ConfigurationProvider)
                .ToListAsync();
            return ingredients;
        }

        public async Task<IEnumerable<ProductSizeModel>> GetSizesAsync()
        {
            var sizes = await context.ProductSizes
                .ProjectTo<ProductSizeModel>(mapper.ConfigurationProvider)
                .ToListAsync();
            return sizes;
        }


        public async Task<ProductItemModel> Edit(ProductEditModel model)
        {
            var item = await context.Products
             .Where(x => x.Id == model.Id)
             .ProjectTo<ProductItemModel>(mapper.ConfigurationProvider)
             .SingleOrDefaultAsync();

            var entity = await context.Products
              .Include(x => x.ProductIngredients)
              .SingleOrDefaultAsync(x => x.Id == model.Id);

            if (item == null)
                throw new Exception("Продукт не знайдено");

            entity.Name = model.Name;
            entity.Slug = model.Slug;
            entity.Price = model.Price;
            entity.Weight = model.Weight;
            entity.ProductSizeId = model.ProductSizeId;
            var categoryExists = await context.Categories.AnyAsync(c => c.Id == model.CategoryId);
            if (!categoryExists)
                throw new Exception("Вказана категорія не існує");
            else
            {
                entity.CategoryId = model.CategoryId;
            }


             entity.ProductIngredients.Clear();
            foreach (var ingId in model.IngredientIds)
            {
                entity.ProductIngredients.Add(new ProductIngredientEntity
                {
                    IngredientId = ingId,
                    ProductId = entity.Id
                });
            }

            //Якщо фото немає у списку, то видаляємо його
            var imgDelete = item.ProductImages
                .Where(x => !model.ImageFiles!.Any(y => y.FileName == x.Name))
                .ToList();

            foreach (var img in imgDelete)
            {
                var productImage = await context.ProductImages
                    .Where(x => x.Id == img.Id)
                    .SingleOrDefaultAsync();
                if (productImage != null)
                {
                    await imageService.DeleteImageAsync(productImage.Name);
                    context.ProductImages.Remove(productImage);
                }
                context.SaveChanges();
            }

            short p = 0;
            // Iterate through all images and save or update them
            foreach (var imgFile in model.ImageFiles!)
            {
                if (imgFile.ContentType == "old-image")
                {
                    var img = await context.ProductImages
                        .Where(x => x.Name == imgFile.FileName)
                        .SingleOrDefaultAsync();
                    if (img != null)
                    {
                        img.Priority = p;
                        context.SaveChanges();
                    }
                }
                else
                {
                    try
                    {
                        var productImage = new ProductImageEntity
                        {
                            ProductId = item.Id,
                            Name = await imageService.SaveImageAsync(imgFile),
                            Priority = p
                        };
                        context.ProductImages.Add(productImage);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error Json Parse Data for PRODUCT IMAGE", ex.Message);
                    }
                }

                p++;
            }

            await context.SaveChangesAsync();
            return item;
        }






    }
}
