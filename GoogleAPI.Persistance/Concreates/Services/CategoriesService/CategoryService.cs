using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Models.Category;
using GoogleAPI.Domain.Models.Category.Dto;
using GoogleAPI.Domain.Models.Category.ViewModel;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.Abstractions.IServices.ICategory;
using GooleAPI.Application.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GoogleAPI.Persistance.Concreates.Services.CategoriesService
{
    public class CategoryService : ICategoryService
    {
        private readonly GooleAPIDbContext _context;
        private readonly ICategoryWriteRepository _cw;
        private readonly ICategoryReadRepository _cr;


        private readonly string ErrorTextBase = "İstek Sırasında Hata Oluştu: ";

        public CategoryService(
            GooleAPIDbContext context,
            ICategoryWriteRepository cw,
            ICategoryReadRepository cr

        )
        {
            _cw = cw;
            _cr = cr;

            _context = context;
        }

        public async Task<List<MainCategory_VM>> GetMainCategories(int id)
        {

            List<Category> allCategories = new List<Category>();

            if (id == 0)
            {
                allCategories = await _cr.Table.Where(c => c.IsActive == true).ToListAsync();
            }
            else
            {
                allCategories = await _cr.Table.Where(c => c.IsActive == true && c.Id == id).ToListAsync();
            }
            List<Category> allMainCategories = allCategories.Where(c => c.IsActive == true && c.TopCategoryId == 0).ToList();
            List<Category> allSubCategories = allCategories.Where(c => c.IsActive == true && c.TopCategoryId != 0).ToList();

            List<MainCategory_VM> mainCategoryVMs = new List<MainCategory_VM>();

            List<MainCategory_VM> allCategoryVMs = allMainCategories.Select(c => MapMainCategoryToVM(c, allCategories, allSubCategories)).ToList();

            mainCategoryVMs.AddRange(allCategoryVMs);

            return mainCategoryVMs;
        }

        public async Task<List<SubCategory_VM>> GetSubCategories(int id)
        {
            List<Category> allCategories = new List<Category>();

            if (id == 0)
            {
                allCategories = await _cr.Table.Where(c => c.IsActive == true).ToListAsync();
            }
            else
            {
                allCategories = await _cr.Table.Where(c => c.IsActive == true && c.Id == id).ToListAsync();
            }
            List<Category> allMainCategories = allCategories.Where(c => c.IsActive == true && c.TopCategoryId == 0).ToList();
            List<Category> allSubCategories = allCategories.Where(c => c.IsActive == true && c.TopCategoryId != 0).ToList();

            List<SubCategory_VM> mainCategoryVMs = new List<SubCategory_VM>();

            List<SubCategory_VM> allCategoryVMs = allSubCategories.Select(c => MapSubCategoryToVM2(c, allCategories, allSubCategories)).ToList();

            mainCategoryVMs.AddRange(allCategoryVMs);

            return mainCategoryVMs;
        }

        private SubCategory_VM MapSubCategoryToVM2(Category subCategory, List<Category> allCategories, List<Category> allSubCategories)
        {
            var topCategory = allCategories.FirstOrDefault(c => c.Id == subCategory.TopCategoryId);

            var subCategoryVM = new SubCategory_VM
            {
                Id = subCategory.Id,
                Description = subCategory?.Description + "-" + subCategory?.Id,
                TopCategoryCategoryId = topCategory?.Id,
                TopCategoryDescription = topCategory?.Description + "-" + topCategory?.Id,
                SubCategories = allSubCategories
                    .Where(sc => sc.TopCategoryId == subCategory.Id)
                    .Select(sc => MapSubCategoryToVM(sc, subCategory, allCategories, allSubCategories))
                    .ToList()
            };

            return subCategoryVM;
        }


        private MainCategory_VM MapMainCategoryToVM(Category category, List<Category> allCategories, List<Category> allSubCategories)
        {
            var mainCategoryVM = new MainCategory_VM
            {
                Id = category.Id,
                Description = category.Description + "-" + category.Id.ToString(),

                SubCategories = allSubCategories
                    .Where(sc => sc.TopCategoryId == category.Id)
                    .Select(sc => MapSubCategoryToVM(sc, category, allCategories, allSubCategories))
                    .ToList()
            };

            return mainCategoryVM;
        }

        private SubCategory_VM MapSubCategoryToVM(Category subCategory, Category topCategory, List<Category> allCategories, List<Category> allSubCategories)
        {
            var subCategoryVM = new SubCategory_VM
            {
                Id = subCategory.Id,
                Description = subCategory.Description + "-" + subCategory.Id.ToString(),
                TopCategoryCategoryId = topCategory.Id,
                TopCategoryDescription = topCategory.Description + "-" + topCategory.Id,
                SubCategories = allSubCategories
                    .Where(sc => sc.TopCategoryId == subCategory.Id)
                    .Select(sc => MapSubCategoryToVM(sc, subCategory, allCategories, allSubCategories))
                    .ToList()
            };

            return subCategoryVM;
        }

        public async Task<List<CategoriesList_VM>> GetAllCategories(int id)
        {
            try
            {
                List<Category> allCategories = await _cr.Table.Where(c => c.IsActive == true).ToListAsync();
                List<Category> allMainCategories = allCategories.Where(c => c.IsActive == true && c.TopCategoryId == 0).ToList();
                List<Category> allSubCategories = allCategories.Where(c => c.IsActive == true && c.TopCategoryId != 0).ToList();

                List<CategoriesList_VM> list = allMainCategories.Select(s => new CategoriesList_VM()
                {
                    Id = s.Id,
                    Description = s.Description,
                    CategoryTypeId = 0,
                }).ToList();

                List<CategoriesList_VM> list2 = allSubCategories.Select(s => new CategoriesList_VM()
                {
                    Id = s.Id,
                    Description = s.Description,
                    CategoryTypeId = 1,
                }).ToList();

                list.AddRange(list2);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception($"GetListOfAllCategories method failed: {ex.Message}", ex);
            }
        }

        public async Task<bool> AddCategory(CategoryAdd_DTO model) // değiştir
        {
            try
            {
                Category mainCategory = new Category
                {
                    Description = model.Description,
                    PhotoUrl = null,
                    IsActive = model.IsActive,
                    CreatedDate = DateTime.Now,
                    TopCategoryId = model.TopCategoryId

                };

                await _cw.AddAsync(mainCategory);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"AddMainCategory method failed: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteCategory(int id)
        {
            try
            {
                Category mainCategory = await _cr.GetByIdAsync(id, false);
                if (mainCategory == null)
                {
                    return false;
                }

                bool response = _cw.Remove(mainCategory);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"DeleteMainCategory method failed: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateCategoryVisibleOption(UpdateCategoryVisibleOptionsCommandModel model)
        {
            Category mainCategory = await _cr.GetByIdAsync(model.Id, false);
            if (mainCategory == null)
            {
                return false;
            }
            mainCategory.IsActive = model.IsActive;
            ;
            var response = await _cw.Update(mainCategory);
            return response;

        }
    }
}
