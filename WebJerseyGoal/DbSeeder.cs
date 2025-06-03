using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebJerseyGoal.Constants;
using Domain;
using Domain.Entitties;
using Domain.Entitties.Identity;
using Core.Interfaces;
using Core.Models.Seeder;

namespace WebJerseyGoal
{
    public static class DbSeeder
    {
        public static async Task SeedData(this WebApplication webApplication)
        {
            using var scope = webApplication.Services.CreateScope();
            //Цей об'єкт буде верта посилання на конткетс, який зараєстрвоано в Progran.cs
            var context = scope.ServiceProvider.GetRequiredService<AppDbJerseyGoalContext>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<RoleEntity>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserEntity>>();
            var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

            context.Database.Migrate();

            if (!context.Categories.Any())
            {
                var imageService = scope.ServiceProvider.GetRequiredService<IImageService>();
                var jsonFile = Path.Combine(Directory.GetCurrentDirectory(), "JsonData", "Categories.json");
                if (File.Exists(jsonFile))
                {
                    var jsonData = await File.ReadAllTextAsync(jsonFile);
                    try
                    {
                        var categories =  JsonSerializer.Deserialize<List<SeederCategoryModel>>(jsonData);
                        var categoryEntities = mapper.Map<List<CategoryEntity>>(categories);
                        foreach (var entity in categoryEntities)
                        {
                            entity.Image =
                            await imageService.SaveImageFromUrlAsync(entity.Image);
                        }

                        await context.AddRangeAsync(categoryEntities);
                        await context.SaveChangesAsync();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error Json Parse Data {0}", ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Not Found File Categories.json");
                }
            }

            if (!context.Ingredients.Any())
            {
                var imageService = scope.ServiceProvider.GetRequiredService<IImageService>();
                var jsonFile = Path.Combine(Directory.GetCurrentDirectory(), "JsonData", "Ingridients.json");
                if (File.Exists(jsonFile))
                {
                    var jsonData = await File.ReadAllTextAsync(jsonFile);
                    try
                    {
                        var ingridients = JsonSerializer.Deserialize<List<SeederIngridientModel>>(jsonData);
                        var ingridientEntities = mapper.Map<List<IngredientEntity>>(ingridients);
                        foreach (var entity in ingridientEntities)
                        {
                            entity.Image =
                            await imageService.SaveImageFromUrlAsync(entity.Image);
                        }

                        await context.Ingredients.AddRangeAsync(ingridientEntities);
                        await context.SaveChangesAsync();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error Json Parse Data {0}", ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Not Found File Categories.json");
                }
            }

            if (!context.ProductSizes.Any())
            {
                var jsonFile = Path.Combine(Directory.GetCurrentDirectory(), "JsonData", "ProductSizes.json");
                if (File.Exists(jsonFile))
                {
                    var jsonData = await File.ReadAllTextAsync(jsonFile);
                    try
                    {
                        var items = JsonSerializer.Deserialize<List<SeederProductSizeModel>>(jsonData);
                        var productSizeEntities = mapper.Map<List<ProductSizeEntity>>(items);
                        await context.ProductSizes.AddRangeAsync(productSizeEntities);
                        await context.SaveChangesAsync();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error Json Parse Data {0}", ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Not Found File Categories.json");
                }
            }

            if (!context.Products.Any())
            {
                var caesar = new ProductEntity
                {
                    Name = "Цезаре",
                    Slug = "caesar",
                    Price = 195,
                    Weight = 540,
                    CategoryId = 1, // Assuming the first category is for Caesar
                    ProductSizeId = 1 // Assuming the first size is for Caesar
                };

                context.Products.Add(caesar);
                await context.SaveChangesAsync();

                //var ingredients = context.Ingredients.ToList();

                foreach (var ingredient in ingredients)
                {
                    var productIngredient = new ProductIngredientEntity
                    {
                        ProductId = caesar.Id,
                        IngredientId = ingredient.Id
                    };
                    context.ProductIngredients.Add(productIngredient);
                }

                await context.SaveChangesAsync();
                
                string[] images = {
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQRN9gItVjEVGS7l2_WkYpNfWJa5y_XQcZ0hQ&s",
                "https://cdn.lifehacker.ru/wp-content/uploads/2022/03/11187_1522960128.7729_1646727034-1170x585.jpg"
                };

                var imageService = scope.ServiceProvider.GetRequiredService<IImageService>();
                foreach (var imageUrl in images)
                {
                    try
                    {
                        var productImage = new ProductImageEntity
                        {
                            ProductId = caesar.Id,
                            Name = await imageService.SaveImageFromUrlAsync(imageUrl)
                        };
                        context.ProductImages.Add(productImage);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error Save Image {0} - {1}", imageUrl, ex.Message);
                    }
                }
                await context.SaveChangesAsync();
                
            }


            if (!context.Roles.Any())
            {
                foreach (var roleName in Roles.AllRoles)
                {
                    var result = await roleManager.CreateAsync(new(roleName));
                    if (!result.Succeeded)
                    {
                        Console.WriteLine("Error Create Role{0}", roleName);
                    }
                }
            }


            if (!context.Users.Any())
            {
                var imageService = scope.ServiceProvider.GetRequiredService<IImageService>();
                var jsonFile = Path.Combine(Directory.GetCurrentDirectory(), "JsonData", "Users.json");
                if (File.Exists(jsonFile))
                {
                    var jsonData = await File.ReadAllTextAsync(jsonFile);
                    try
                    {
                        var users = JsonSerializer.Deserialize<List<SeederUserModel>>(jsonData);
                        foreach (var user in users)
                        {
                            var entity = mapper.Map<UserEntity>(user);
                            entity.UserName = user.Email;
                            entity.Image = await imageService.SaveImageFromUrlAsync(user.Image);
                            var result = await userManager.CreateAsync(entity, user.Password);
                            if (!result.Succeeded)
                            {
                                Console.WriteLine("Error Create User {0}", user.Email);
                                continue;
                            }
                            foreach (var role in user.Roles)
                            {
                                if (await roleManager.RoleExistsAsync(role))
                                {
                                    await userManager.AddToRoleAsync(entity, role);
                                }
                                else
                                {
                                    Console.WriteLine("Not Found Role {0}", role);
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error Json Parse Data {0}", ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Not Found File Users.json");
                }
            }

         
       


          



        }


    }
}
