// MainCategorysController.cs

using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Models.Category;
using GoogleAPI.Domain.Models.Category.Dto;
using GoogleAPI.Domain.Models.Category.ViewModel;
using GooleAPI.Application.Abstractions.IServices.ICategory;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAPI.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    //[Authorize(AuthenticationSchemes ="Admin")]
    public class MainCategorysController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public MainCategorysController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet("get-main-category")]
        public async Task<ActionResult<IEnumerable<MainCategory_VM>>> GetMainCategorys(int id)
        {
            try
            {
                List<MainCategory_VM> mainCategories = await _categoryService.GetMainCategories(id);
                return mainCategories;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("get-sub-category")]
        public async Task<ActionResult<IEnumerable<SubCategory_VM>>> GetSubCategorys(int id)
        {
            try
            {
                List<SubCategory_VM> subCategories = await _categoryService.GetSubCategories(id);
                return subCategories;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("get-all-categories")]
        public async Task<ActionResult<IEnumerable<CategoriesList_VM>>> GetAllCategories(int id)
        {
            try
            {
                List<CategoriesList_VM> categories = await _categoryService.GetAllCategories(id);
                return categories;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult<Category>> AddCategory(CategoryAdd_DTO model)
        {
            try
            {
                bool response = await _categoryService.AddCategory(model);

                if (response)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("MainCategory could not be added.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UpdateCategoryVisibleOption")]
        public async Task<ActionResult<bool>> UpdateCategoryVisibleOption(UpdateCategoryVisibleOptionsCommandModel model)
        {
            try
            {
                bool response = await _categoryService.UpdateCategoryVisibleOption(model);
                if (response)
                {
                    return Ok(true);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                bool response = await _categoryService.DeleteCategory(id);

                if (response)
                {
                    return Ok(true);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
