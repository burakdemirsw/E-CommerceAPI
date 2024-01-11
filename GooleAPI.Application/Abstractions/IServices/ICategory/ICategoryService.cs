using GoogleAPI.Domain.Models.Category;
using GoogleAPI.Domain.Models.Category.Dto;
using GoogleAPI.Domain.Models.Category.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooleAPI.Application.Abstractions.IServices.ICategory
{
    public interface ICategoryService
    {
        Task<List<MainCategory_VM>> GetMainCategories(int id);
        Task<List<SubCategory_VM>> GetSubCategories(int id);
        Task<List<CategoriesList_VM>> GetAllCategories(int id);
        Task<bool> UpdateCategoryVisibleOption(UpdateCategoryVisibleOptionsCommandModel model);
        Task<bool> AddCategory(CategoryAdd_DTO model);
        Task<bool> DeleteCategory(int id);

    }
}
