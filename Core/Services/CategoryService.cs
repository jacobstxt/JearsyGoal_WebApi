using AutoMapper;
using Core.Interfaces;
using Core.Models.Category;
using Domain;
using Domain.Entitties;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class CategoryService(AppDbJerseyGoalContext jerseyContext, IMapper mapper, IImageService imageService) : ICategoryService
    {
        public async Task<CategoryItemViewModel> Create(CategoryCreateViewModel model)
        {
            var entity = mapper.Map<CategoryEntity>(model);
            entity.Image = await imageService.SaveImageAsync(model.Image!);
            await jerseyContext.Categories.AddAsync(entity);
            await jerseyContext.SaveChangesAsync();
            return mapper.Map<CategoryItemViewModel>(entity);
        }

        public async Task<CategoryItemViewModel?> Delete(int id)
        {
            var category = await jerseyContext.Categories.SingleOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(category.Image))
            {
                await imageService.DeleteImageAsync(category.Image);
            }
            jerseyContext.Categories.Remove(category);
            await jerseyContext.SaveChangesAsync();

            return mapper.Map<CategoryItemViewModel>(category);
        }

        public async Task<CategoryItemViewModel> Edit(CategoryEditViewModel model)
        {
            var existing = await jerseyContext.Categories.FirstOrDefaultAsync(x => x.Id == model.Id);
            existing = mapper.Map(model, existing);

            if (model.Image != null)
            {
                await imageService.DeleteImageAsync(existing.Image);
                existing.Image = await imageService.SaveImageAsync(model.Image);
            }
            await jerseyContext.SaveChangesAsync();

            var item = mapper.Map<CategoryItemViewModel>(existing);
            return item;
        }

        public async Task<CategoryItemViewModel?> GetItemById(int id)
        {
            var model = await mapper
              .ProjectTo<CategoryItemViewModel>(jerseyContext.Categories.Where(x => x.Id == id))
              .SingleOrDefaultAsync();
            return model;
        }

        public async Task<List<CategoryItemViewModel>> List()
        {
            var model = await mapper.ProjectTo<CategoryItemViewModel>(jerseyContext.Categories)
             .ToListAsync();
            return model;
        }
    }
}
