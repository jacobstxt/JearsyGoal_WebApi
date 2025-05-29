using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Category;

namespace Core.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryItemViewModel>> List();
        Task<CategoryItemViewModel?> GetItemById(int id);
        Task<CategoryItemViewModel> Create(CategoryCreateViewModel model);
        Task<CategoryItemViewModel> Edit(CategoryEditViewModel model);
        Task<CategoryItemViewModel?> Delete(int id);

    }
}
