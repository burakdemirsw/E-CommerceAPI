using GoogleAPI.Domain.Models.Category.ViewModel;
using GoogleAPI.Domain.Models.Product.CommandModel;
using GoogleAPI.Domain.Models.Product.Dto;
using GoogleAPI.Domain.Models.Product.Filters;
using GoogleAPI.Domain.Models.Product.ResponseModel;
using GoogleAPI.Domain.Models.Product.ViewModel;
using GoogleAPI.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooleAPI.Application.Abstractions.IServices.IProduct
{
    public interface IProductService
    {
        Task<List<ProductVariation_VM>> GetVariationsByFilter(string stockCode);
        Task<List<ProductDetail_VM>> GetProductsByBrandName(string brandName);
        Task<List<ProductDetail_VM>> GetSingleProductDetail(ProductCard_DTO model);
        Task<ResponseModel<ProductCard_VM>> GetProductCards(GetProductCardsFilter model); Task<List<ProductPreviewCard_VM>> GetProductCardsPreview(string? stockCode);

        Task<List<ProductCard_VM>> GetProductCardsByBrandId(string? brandId);
        Task<bool> AddProduct(ProductAdd_DTO productDto,bool checkStockCode,bool addCategory, bool IsNew); //---
        Task<bool> UpdateProduct(ProductAdd_DTO productDto);//---
        Task<bool> CheckProductByStockCode(string stockCode);
        Task<List<CategoriesList_VM>> GetCategoriesOfProduct(string stockCode);
        Task<List<ProductVariation_VM>> GetVariationsList(GetVariationsIdListCommandModel model);
        Task<List<Dimention_VM>> GetDimentionsOfProduct(string stockCode,int colorId);
        Task<List<Color_VM>> GetColorsOfProduct(string stockCode, int colorId);
        Task<List<GetProductPhotoResponse>> GetProductPhotos(GetProductPhotoCommandModel model);
        Task<bool> UploadProductPhotos(UploadProductPhotoCommandModel model);
        Task<bool> DeleteProductPhotoByPhotoId(DeleteProductPhotoByIdCommandModel model);
        Task<bool> DeleteProductCard(ProductCard_DTO model);
        Task<bool> UpdateProductStockById(UpdateProductStockByIdComandModel model); //---
        Task<bool> UpdateFistPhotoOfCard(UpdateFistPhotoOfCardCommandModel model);


    }
}
