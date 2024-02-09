using GoogleAPI.Domain.Models.Category.ViewModel;
using GoogleAPI.Domain.Models.Order.CommandModel;
using GoogleAPI.Domain.Models.Product.CommandModel;
using GoogleAPI.Domain.Models.Product.Dto;
using GoogleAPI.Domain.Models.Product.Filters;
using GoogleAPI.Domain.Models.Product.ViewModel;
using GoogleAPI.Domain.Models.Response;
using GooleAPI.Application.Abstractions.IServices.IProduct;
using GooleAPI.Application.Consts;
using GooleAPI.Application.CustomAttributes;
using GooleAPI.Application.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAPI.API.Controllers
{
    [Route("api/products")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<IProductService> _logger;
        public ProductsController(IProductService productService, ILogger<IProductService> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet("GetProductVariation")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Reading, Definition = "Get Variations By Filter")]
        public async Task<IActionResult> GetVariationsByFilter(string stockCode)
        {
            var models = await _productService.GetVariationsByFilter(stockCode);
            return Ok(models);
        }

        //Bu alan client tarafından kullanılır marka ya da ürün kartına tıklandığında gelicek olan model buradan çağırılır.
        [HttpGet("get-products-by-brandName/{brandName}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Reading, Definition = "Get Products By Brand Name")]
        public async Task<IActionResult> GetProductsByBrandName(string brandName)
        {
            var models = await _productService.GetProductsByBrandName(brandName);
            return Ok(models);
        }

        [HttpPost("get-single-product-detail")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Reading, Definition = "Get Single Product Detail")]
        public async Task<IActionResult> GetSingleProductDetail(ProductCard_DTO model)
        {
            var models = await _productService.GetSingleProductDetail(model);
            return Ok(models);
        }

        //Bu alan admin panel  kullanılır ürün listeleme sayfasına gelicek olan  model buradan çağırılır.
        [HttpPost("GetProductCards")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Reading, Definition = "Get Product Cards")]

        public async Task<ActionResult<ResponseModel<ProductCard_VM>>> GetProductCards(GetProductCardsFilter model)
        {
            _logger.LogInformation("Ürünler Çekildi");
            var models = await _productService.GetProductCards(model);
            return Ok(models);
        }

        [HttpPost("get-product-cards-preview")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Reading, Definition = "Get Product Cards Preview")]

        public async Task<IActionResult> GetProductCardsPreview(string? stockCode)
        {
            _logger.LogInformation("GetProductCardsPreview Çekildi");
            var models = await _productService.GetProductCardsPreview(stockCode);
            return Ok(models);
        }



        [HttpPost("GetProductCardsByBrandId")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Reading, Definition = "Get Product Cards By BrandId")]
        public async Task<IActionResult> GetProductCardsByBrandId(string? brandId)
        {
            var models = await _productService.GetProductCardsByBrandId(brandId);
            return Ok(models);
        }
        [HttpPost("AddProduct")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Writing, Definition = "Add Product")]
        public async Task<IActionResult> AddProduct(ProductAdd_DTO productDto)
        {
            var response = await _productService.AddProduct(productDto, true, true, true);

            if (response)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("Ürün eklenirken bir hata oluştu.");
            }
        }

        [HttpPost("get-variations-list")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        //[AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Reading, Definition = "Get Variations List")]
        public async Task<ActionResult<List<ProductVariation_VM>>> GetVariationsList(GetVariationsIdListCommandModel model)
        {

            try
            {
                List<ProductVariation_VM> response = await _productService.GetVariationsList(model);

                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpGet("CheckProductByStockCode/{stockCode}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Reading, Definition = "Check Product By StockCode")]
        public async Task<IActionResult> CheckProductByStockCode(string stockCode)
        {

            try
            {
                var response = await _productService.CheckProductByStockCode(stockCode);
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPost("update")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Updating, Definition = "Update Product")]
        public async Task<ActionResult<bool>> UpdateProduct(ProductAdd_DTO productDto)
        {
            try
            {
                bool result = await _productService.UpdateProduct(productDto);

                if (result)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("Ürün güncellenirken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("upload-photoduct-photos")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Writing, Definition = "Upload Product Photos")]
        public async Task<ActionResult<bool>> UploadProductPhotos(UploadProductPhotoCommandModel model)
        {
            try
            {
                bool result = await _productService.UploadProductPhotos(model);

                if (result)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("Fotoğraf eklenirken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("get-product-photos")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Reading, Definition = "Get Product Photos")]
        public async Task<ActionResult<List<GetProductPhotoResponse>>> GetProductPhotos(GetProductPhotoCommandModel model)
        {
            try
            {
                var result = await _productService.GetProductPhotos(model);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Fotoğraf eklenirken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("delete-product-photo-by-id")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Deleting, Definition = "Delete Product Photo By PhotoId")]
        public async Task<ActionResult<bool>> DeleteProductPhotoByPhotoId(DeleteProductPhotoByIdCommandModel model)
        {
            try
            {
                bool result = await _productService.DeleteProductPhotoByPhotoId(model);

                if (result)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("Fotoğraf silinirken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("delete-product-card")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Deleting, Definition = "Delete Product Card")]
        public async Task<ActionResult<bool>> DeleteProductCard(ProductCard_DTO model)
        {
            try
            {
                bool result = await _productService.DeleteProductCard(model);

                if (result)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("Fotoğraf silinirken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update-product-stock-by-id")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Updating, Definition = "Update Product Stock By Id")]
        public async Task<ActionResult<bool>> UpdateProductStockById(UpdateProductStockByIdComandModel model)
        {
            try
            {
                bool result = await _productService.UpdateProductStockById(model);

                if (result)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("Fotoğraf silinirken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("get-categories-of-product")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Reading, Definition = "Get Categories Of Product")]
        public async Task<ActionResult<CategoriesList_VM>> GetCategoriesOfProduct(GetVariationsIdListCommandModel model)
        {
            try
            {
                List<CategoriesList_VM>? list = await _productService.GetCategoriesOfProduct(model.StockCode);

                if (list != null)
                {
                    return Ok(list);
                }
                else
                {
                    return BadRequest("Ürün güncellenirken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update-fist-photo-of-card")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Updating, Definition = "Update Fist Photo Of Card")]
        public async Task<ActionResult<CategoriesList_VM>> UpdateFistPhotoOfCard(UpdateFistPhotoOfCardCommandModel model)
        {
            try
            {
                bool result = await _productService.UpdateFistPhotoOfCard(model);

                if (result)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("Fotoğraf güncellenirken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //        Task<BasketProduct_VM> GetBasketProductsByFilter(GetBasketProductsFilter model);

        [HttpPost("get-basket-product-by-filter")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        //[AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Reading, Definition = "Get Basket Products By Filter")]
        public async Task<ActionResult<List<GetBasketProductsFilter_ResponseModel>>> GetBasketProductsByFilter(GetBasketProductsFilter_CommandModel model)
        {
            try
            {
                var result = await _productService.GetBasketProductsByFilter(model);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Ürünler Getirilirken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
