﻿// ProductService.cs

using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Models.Category.ViewModel;
using GoogleAPI.Domain.Models.Order.CommandModel;
using GoogleAPI.Domain.Models.Product.CommandModel;
using GoogleAPI.Domain.Models.Product.Dto;
using GoogleAPI.Domain.Models.Product.Filters;
using GoogleAPI.Domain.Models.Product.ViewModel;
using GoogleAPI.Domain.Models.Response;
using GoogleAPI.Domain.Models.Supplier.ViewModel;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.Abstractions.IServices.IProduct;
using GooleAPI.Application.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GooleAPI.Persistance.Services.ProductsService
{
    public class ProductService : IProductService
    {
        private readonly GooleAPIDbContext _c;

        private readonly IProductWriteRepository _pw;
        private readonly IProductReadRepository _pr;
        private readonly IPhotoWriteRepository _ph;
        public ProductService(GooleAPIDbContext context, IProductWriteRepository pw, IProductReadRepository pr, IPhotoWriteRepository ph)
        {
            _c = context;

            _pr = pr;
            _pw = pw;
            _ph = ph;
        }

        public async Task<List<ProductVariation_VM>> GetVariationsByFilter(string stockCode)
        {
            try
            {
                var query = $"exec GetProductVariation '{stockCode}'";
                return await _c.ProductVariation_VM.FromSqlRaw(query).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception($"GetVariationsByFilter method failed: {ex.Message}", ex);
            }
        }
        //

        public async Task<List<ProductDetail_VM>> GetSingleProductDetail(ProductCard_DTO model)
        {
            try
            {
                var query = from p in _c.Products
                            join c in _c.Colors on p.ColorId equals c.Id
                            join b in _c.Brands on p.BrandId equals b.Id
                            join pp in _c.ProductPhotos on p.Id equals pp.ProductId into photoGroup
                            from pp in photoGroup.DefaultIfEmpty() // Left join için kullanılır
                            join ph in _c.Photos on pp.PhotoId equals ph.Id into photoInfo
                            from ph in photoInfo.DefaultIfEmpty() // Left join için kullanılır
                            where p.StockCode == model.StockCode && p.ColorId == model.ColorId
                            group new { p, pp, ph } by new
                            {
                                p.StockCode,
                                Description = p.Description + "-" + c.Description,
                                p.CoverLetter,
                                p.NormalPrice,
                                p.PurchasePrice,
                                p.DiscountedPrice,
                                p.VATRate,
                                p.IsActive,
                                p.IsNew,
                                p.IsFreeCargo,
                                p.ColorId,
                                BrandDescription = b.Description
                            } into g
                            select new ProductDetail_VM
                            {
                                Color = g.Key.ColorId.ToString(),
                                StockCode = g.Key.StockCode,
                                Description = g.Key.Description,
                                Brand = g.Key.BrandDescription,
                                NormalPrice = g.Key.NormalPrice,
                                PurchasePrice = g.Key.PurchasePrice,
                                DiscountedPrice = g.Key.DiscountedPrice,
                                PhotoUrl = g.Select(item => item.ph.Url).Distinct().Select(url => new Photo_VM { Url = url }).ToList(),
                                Variations = _c.Products.Where(p => p.StockCode == g.Key.StockCode && p.ColorId == g.Key.ColorId).Select(pr => new Variant_VM()
                                {
                                    DimensionDescription = _c.Dimensions.FirstOrDefault(d => d.Id == pr.DimensionId).Description == null ? null : _c.Dimensions.FirstOrDefault(d => d.Id == pr.DimensionId).Description,
                                    DimensionId = pr.DimensionId,
                                    Quantity = pr.StockAmount.ToString(),
                                }).ToList(),
                            };
                var models = await query.ToListAsync();

                return models;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception($"GetProductDetail method failed: {ex.Message}", ex);
                return null;

            }
        }
        public async Task<List<ProductDetail_VM>> GetProductsByBrandName(string brandName)
        {
            try
            {
                var query = from p in _c.Products
                            join c in _c.Colors on p.ColorId equals c.Id
                            join b in _c.Brands on p.BrandId equals b.Id
                            join pp in _c.ProductPhotos on p.Id equals pp.ProductId into photoGroup
                            from pp in photoGroup.DefaultIfEmpty() // Left join için kullanılır
                            join ph in _c.Photos on pp.PhotoId equals ph.Id into photoInfo
                            from ph in photoInfo.DefaultIfEmpty() // Left join için kullanılır
                            where b.Description == brandName
                            group new { p, pp, ph } by new
                            {
                                p.StockCode,
                                Description = p.Description + "-" + c.Description,
                                p.CoverLetter,
                                p.NormalPrice,
                                p.PurchasePrice,
                                p.DiscountedPrice,
                                p.VATRate,
                                p.IsActive,
                                p.IsNew,
                                p.IsFreeCargo,
                                p.ColorId,
                                BrandDescription = b.Description
                            } into g
                            select new ProductDetail_VM
                            {
                                Color = g.Key.ColorId.ToString(),
                                StockCode = g.Key.StockCode,
                                Description = g.Key.Description,
                                Brand = g.Key.BrandDescription,
                                NormalPrice = g.Key.NormalPrice,
                                PurchasePrice = g.Key.PurchasePrice,
                                DiscountedPrice = g.Key.DiscountedPrice,
                                PhotoUrl = g.Select(item => item.ph.Url).Distinct().Select(url => new Photo_VM { Url = url }).ToList(),
                                Variations = _c.Products.Where(p => p.StockCode == g.Key.StockCode && p.ColorId == g.Key.ColorId).Select(pr => new Variant_VM()
                                {
                                    DimensionDescription = _c.Dimensions.FirstOrDefault(d => d.Id == pr.DimensionId).Description == null ? null : _c.Dimensions.FirstOrDefault(d => d.Id == pr.DimensionId).Description,
                                    DimensionId = pr.DimensionId,
                                    Quantity = pr.StockAmount.ToString(),
                                }).ToList(),
                            };
                var models = await query.ToListAsync();

                return models;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception($"GetProductDetail method failed: {ex.Message}", ex);
                return null;

            }
        }

        public async Task<List<ProductPreviewCard_VM>> GetProductCardsPreview(string? stockCode)
        {
            List<Brand> brands = new List<Brand>();
            List<ProductPreviewCard_VM> previewCards = new List<ProductPreviewCard_VM>();
            brands = _c.Brands.ToList();

            Random random = new Random(); // Rasgele sıralama için rastgele sayı üreteci oluşturun

            foreach (var brand in brands)
            {
                ProductPreviewCard_VM previewCard = new ProductPreviewCard_VM();
                previewCard.Brand = brand.Description;

                // Markaya ait tüm fotoğraf URL'lerini alın (tekrar edenleri çıkartın)
                var allUrls = (from ph in _c.Photos
                               join pp in _c.ProductPhotos on ph.Id equals pp.PhotoId
                               join p in _c.Products on pp.ProductId equals p.Id
                               join b in _c.Brands on p.BrandId equals b.Id
                               where b.Description == brand.Description
                               select ph.Url
                              ).Distinct().ToList();

                // Eksik URL sayısını hesaplayın
                int missingCount = 4 - allUrls.Count;

                if (missingCount > 0)
                {
                    // Eksik URL'leri mevcut URL'lerden rasgele seçerek doldurun
                    var missingUrls = allUrls.OrderBy(u => random.Next()).Take(missingCount);
                    allUrls.AddRange(missingUrls);
                }

                // Tüm URL'leri rasgele sırayla karıştırın
                var shuffledUrls = allUrls.OrderBy(u => random.Next()).ToList();

                // En fazla 4 URL alın
                var selectedUrls = shuffledUrls.Take(4).ToList();

                previewCard.Photos = selectedUrls.Select(url => new Photo_VM { Url = url }).ToList();

                previewCards.Add(previewCard);
            }

            // Şimdi previewCards listesi, her bir marka için en fazla 4 rasgele sıralanmış ve eksik olanları doldurulmuş fotoğraf URL'sini içerir.



            try
            {

                return previewCards;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception($"GetProductCardsPreview method failed: {ex.Message}", ex);
            }
        }

        public async Task<ResponseModel<ProductCard_VM>> GetProductCards(GetProductCardsFilter model)
        {
            var query = from p in _c.Products
                        join c in _c.Colors on p.ColorId equals c.Id
                        join b in _c.Brands on p.BrandId equals b.Id
                        join pp in _c.ProductPhotos on p.Id equals pp.ProductId into photoGroup
                        from pp in photoGroup.DefaultIfEmpty() // Left join için kullanılır
                        join ph in _c.Photos on pp.PhotoId equals ph.Id into photoInfo
                        from ph in photoInfo.DefaultIfEmpty() // Left join için kullanılır
                        group new { p, pp, ph } by new
                        {
                            p.StockCode,
                            Description = p.Description + "-" + c.Description,
                            p.CoverLetter,
                            p.NormalPrice,
                            p.PurchasePrice,
                            p.DiscountedPrice,
                            p.VATRate,
                            p.IsActive,
                            p.IsNew,
                            p.IsFreeCargo,
                            p.ColorId,
                            BrandDescription = b.Description
                        } into g
                        select new ProductCard_VM
                        {
                            StockCode = g.Key.StockCode,
                            Description = g.Key.Description,
                            CoverLetter = g.Key.CoverLetter,
                            PhotoUrl = g.FirstOrDefault(x => x.pp != null && x.pp.IsFirstPhoto == true).ph.Url == null ? "" : g.FirstOrDefault(x => x.pp != null && x.pp.IsFirstPhoto == true).ph.Url, // İlk "IsFirstPhoto" true olan resmi al
                            Brand = g.Key.BrandDescription,
                            NormalPrice = g.Key.NormalPrice,
                            PurchasePrice = g.Key.PurchasePrice,
                            DiscountedPrice = g.Key.DiscountedPrice,
                            VATRate = g.Key.VATRate,
                            TotalStockAmount = g.Sum(x => x.p.StockAmount), // Toplam stok miktarını hesapla,
                            IsActive = g.Key.IsActive,
                            IsNew = g.Key.IsNew,
                            IsFreeCargo = g.Key.IsFreeCargo,
                            ColorId = g.Key.ColorId
                        };



            try
            {

                int totalCount = await query.CountAsync();

                int skipCount = (model.Pagination.Page - 1) * model.Pagination.Size; // Calculate the number of items to skip
                List<ProductCard_VM> list = await query.Skip(model.Pagination.Size * (model.Pagination.Page - 1)).Take(model.Pagination.Size).ToListAsync();


                ResponseModel<ProductCard_VM> response = new ResponseModel<ProductCard_VM>();
                response.TotalCount = totalCount;
                response.Datas = list;
                return response;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception($"GetProductCards method failed: {ex.Message}", ex);
            }
        }


        public async Task<List<ProductCard_VM>> GetProductCardsByBrandId(string? brandId)
        {
            try
            {
                var query = $"GetProductCardByBrand '{brandId}'";
                return await _c.ProductCard_VM.FromSqlRaw(query).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception($"GetProductCardsByBrandId method failed: {ex.Message}", ex);
            }
        }

        public async Task<bool> AddProduct(ProductAdd_DTO productDto, bool CheckStockCode, bool addCategory, bool IsNew)
        {
            try
            {


                bool response = await CheckProductByStockCode(productDto.StockCode);

                if (true)
                {
                    if (true)
                    {
                        List<Product> productList = new List<Product>();

                        foreach (var color in productDto.ColorIdList)
                        {
                            foreach (var dimension in productDto.ItemDimList)
                            {
                                var product = new Product
                                {
                                    StockCode = productDto.StockCode,
                                    Description = productDto.Description,
                                    DimensionId = dimension,
                                    ColorId = color,
                                    SupplierId = productDto.SupplierId,
                                    BrandId = productDto.BrandId,
                                    Explanation = productDto.Explanation,
                                    CoverLetter = productDto.CoverLetter,
                                    Barcode = Guid.NewGuid().ToString(),
                                    NormalPrice = productDto.NormalPrice,
                                    PurchasePrice = productDto.PurchasePrice,
                                    DiscountedPrice = productDto.DiscountedPrice,
                                    StockAmount = productDto.StockAmount,
                                    VATRate = productDto.VatRate,
                                    IsActive = productDto.IsActive,
                                    IsNew = productDto.IsNew,
                                    IsFreeCargo = productDto.IsFreeCargo,
                                    Ticket_1 = productDto.Ticket_1,
                                    Ticket_2 = productDto.Ticket_2,
                                    Ticket_3 = productDto.Ticket_3,
                                    CreatedDate = DateTime.Now,
                                    UpdatedDate = DateTime.Now,
                                };
                                productList.Add(product);
                            }
                        }

                        foreach (var productItem in productList)
                        {
                            await _pw.AddAsync(productItem);
                        }
                        if (IsNew)
                        {
                            List<Product>? addedProducts = await _pr.Table.Where(p => p.StockCode == productDto.StockCode).ToListAsync();
                            if (addCategory)

                            {

                                await AddCategoryToProduct(addedProducts, productDto.CategoryIdList);
                                if (addedProducts != null)
                                    await _c.SaveChangesAsync();

                                //ilgili stok kodlu ürünlere ait kategori atamaları yapıldı
                            }
                        }
                        else
                        {
                            List<Product>? addedProducts = await _pr.Table.Where(p => p.StockCode == productDto.StockCode && p.DimensionId == productDto.ItemDimList.First() && p.ColorId == productDto.ColorIdList.First()).ToListAsync();
                            if (addCategory)
                            {
                                await AddCategoryToProduct(addedProducts, productDto.CategoryIdList);
                                if (addedProducts != null)
                                    await _c.SaveChangesAsync();
                            }
                        }



                    }

                    return true;
                }
                else
                {

                    throw new Exception("Aynı Stok Koduna Ait Ürün Bulunmaktadır");
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
                throw new Exception($"AddProduct method failed: {ex.Message}", ex);


            }
        }
        public async Task<bool> UpdateProduct(ProductAdd_DTO productDto)
        {
            using var transaction = _c.Database.BeginTransaction(); // Veritabanı işlemi başlatılır
            try
            {
                // İlgili stok koduna sahip ürünü bul
                List<Product>? existingProducts = await _pr.Table.Where(p => p.StockCode == productDto.StockCode).ToListAsync();
                if (existingProducts != null)
                {

                    List<Dimention_VM>? existingDimentions = await GetDimentionsOfProduct(productDto.StockCode, productDto.ColorIdList.First());
                    List<int>? dimentionIdList = existingDimentions.Select(c => c.Id).ToList();
                    if (!productDto.ItemDimList.All(dimId => dimentionIdList.Contains(dimId)))
                    {
                        var differentdimentionIdList = productDto.ItemDimList.Except(dimentionIdList).ToList();
                        foreach (var item in differentdimentionIdList)
                        {
                            ProductAdd_DTO productAdd_DTO = new ProductAdd_DTO();
                            productAdd_DTO = productDto;
                            productAdd_DTO.ItemDimList = new List<int>
                            {
                                item
                            };
                            await AddProduct(productDto, false, true, false);

                        }
                    }
                    List<CategoriesList_VM>? categories = await GetCategoriesOfProduct(existingProducts.First().StockCode);
                    List<int>? categoryIdList = categories.Select(c => c.Id).ToList();
                    if (!productDto.CategoryIdList.All(categoryId => categoryIdList.Contains(categoryId)))
                    {
                        Console.WriteLine("Product categories do not match with existing categories.");

                        // Farklı kategorileri bulmak için iki liste arasındaki farkı hesaplayabilirsiniz.
                        var differentCategories = productDto.CategoryIdList.Except(categoryIdList).ToList();

                        // Farklı kategorileri konsola yazdırabilirsiniz.
                        List<Product> productList = await _c.Products.Where(p => p.StockCode == productDto.StockCode).ToListAsync();

                        await AddCategoryToProduct(productList, differentCategories);

                    }
                    List<Product>? existingProducts2 = await _pr.Table.Where(p => p.StockCode == productDto.StockCode).ToListAsync();
                    foreach (var existingProduct in existingProducts2)
                    {
                        // Yalnızca farklı olan alanları güncelle
                        if (!string.Equals(existingProduct.Description, productDto.Description))
                            existingProduct.Description = productDto.Description;

                        if (existingProduct.BrandId != productDto.BrandId)
                            existingProduct.BrandId = productDto.BrandId;

                        if (!string.Equals(existingProduct.Explanation, productDto.Explanation))
                            existingProduct.Explanation = productDto.Explanation;

                        if (!string.Equals(existingProduct.CoverLetter, productDto.CoverLetter))
                            existingProduct.CoverLetter = productDto.CoverLetter;

                        if (existingProduct.NormalPrice != productDto.NormalPrice)
                            existingProduct.NormalPrice = productDto.NormalPrice;

                        if (existingProduct.PurchasePrice != productDto.PurchasePrice)
                            existingProduct.PurchasePrice = productDto.PurchasePrice;

                        if (existingProduct.DiscountedPrice != productDto.DiscountedPrice)
                            existingProduct.DiscountedPrice = productDto.DiscountedPrice;

                        if (existingProduct.StockAmount != productDto.StockAmount)
                            existingProduct.StockAmount = productDto.StockAmount;

                        if (existingProduct.VATRate != productDto.VatRate)
                            existingProduct.VATRate = productDto.VatRate;

                        if (existingProduct.IsActive != productDto.IsActive)
                            existingProduct.IsActive = productDto.IsActive;

                        if (existingProduct.IsNew != productDto.IsNew)
                            existingProduct.IsNew = productDto.IsNew;

                        if (existingProduct.IsFreeCargo != productDto.IsFreeCargo)
                            existingProduct.IsFreeCargo = productDto.IsFreeCargo;

                        if (!string.Equals(existingProduct.Ticket_1, productDto.Ticket_1))
                            existingProduct.Ticket_1 = productDto.Ticket_1;

                        if (!string.Equals(existingProduct.Ticket_2, productDto.Ticket_2))
                            existingProduct.Ticket_2 = productDto.Ticket_2;

                        if (!string.Equals(existingProduct.Ticket_3, productDto.Ticket_3))
                            existingProduct.Ticket_3 = productDto.Ticket_3;

                        // UpdatedDate'i güncelle
                        var response = await _pw.Update(existingProduct);

                        // Değişiklikleri kaydet

                    }

                    //await _pw.UpdateRange(existingProducts);
                    await transaction.CommitAsync();
                    return true;
                }
                else
                {
                    throw new Exception("Belirtilen stok kodu ile bir ürün bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception($"UpdateProduct method failed: {ex.Message + ex.StackTrace}", ex);
            }
        }

        public async Task<List<ProductVariation_VM>> GetVariationsList(GetVariationsIdListCommandModel model)
        {
            var query = from p in _c.Products
                        join pc in _c.ProductCategories on p.Id equals pc.ProductId
                        join c in _c.Categories on pc.CategoryId equals c.Id
                        group p by new
                        {
                            CategoryDesc = c.Description,
                            CategoryId = c.Id
                        } into g

                        select new CategoriesList_VM
                        {
                            Description = g.Key.CategoryDesc,
                            Id = g.Key.CategoryId,
                            CategoryTypeId = -1
                        };

            try
            {

                List<ProductVariation_VM> list = await (
                  from pr in _c.Products
                  join c in _c.Colors on pr.ColorId equals c.Id
                  join d in _c.Dimensions on pr.DimensionId equals d.Id
                  join br in _c.Brands on pr.BrandId equals br.Id
                  join sp in _c.Suppliers on pr.SupplierId equals sp.Id
                  where pr.StockCode == model.StockCode && pr.ColorId == model.ColorId
                  select new ProductVariation_VM
                  {
                      Id = pr.Id,
                      StockCode = pr.StockCode,
                      Description = pr.Description,
                      Barcode = pr.Barcode,
                      StockAmount = pr.StockAmount,
                      Color = new Color_VM
                      {
                          Description = c.Description,
                          Id = c.Id,
                      },
                      Dimentions = (from d in _c.Dimensions
                                    join p in _c.Products on d.Id equals p.DimensionId
                                    where p.StockCode == model.StockCode && p.ColorId == model.ColorId && p.Id == pr.Id
                                    group p by new
                                    {
                                        DimentionDesc = d.Description,
                                        DimentionId = d.Id
                                    } into g2
                                    select new Dimention_VM
                                    {
                                        Description = g2.Key.DimentionDesc,
                                        Id = g2.Key.DimentionId,
                                    }).ToList(),
                      Brand = new GoogleAPI.Domain.Models.Brand.ViewModel.Brand_VM
                      {
                          Description = br.Description,
                          Id = br.Id,
                          PhotoUrl = br.PhotoUrl
                      },
                      Supplier = new Supplier_VM
                      {
                          Description = sp.Description,
                          Id = sp.Id,

                      },
                      Categories = (query).ToList(),
                      CoverLetter = pr.CoverLetter,
                      NormalPrice = pr.NormalPrice,
                      PurchasePrice = pr.PurchasePrice,
                      DiscountedPrice = pr.DiscountedPrice,
                      VATRate = pr.VATRate,
                      IsActive = pr.IsActive,
                      IsNew = pr.IsNew,
                      IsFreeCargo = pr.IsFreeCargo,
                      CreatedDate = pr.CreatedDate,
                      UpdatedDate = pr.UpdatedDate,
                  }
              ).ToListAsync();

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception($"GetVartiationsList method failed: {ex.Message}", ex);



            }
        }
        public async Task AddCategoryToProduct(List<Product> products, List<int> categoryIdList)
        {
            using var transaction = _c.Database.BeginTransaction(); // Veritabanı işlemi başlatılır

            try
            {
                var productCategoryList = new List<ProductCategory>();

                foreach (var product in products)
                {
                    foreach (var categoryId in categoryIdList)
                    {
                        var productCategory = new ProductCategory
                        {
                            ProductId = product.Id,
                            CategoryId = categoryId
                        };

                        productCategoryList.Add(productCategory);
                    }
                }

                await _c.ProductCategories.AddRangeAsync(productCategoryList);
                await _c.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex.Message);
            }

        }

        public async Task<bool> CheckProductByStockCode(string stockCode)
        {
            Product? product = await _c.Products.FirstOrDefaultAsync(p => p.StockCode == stockCode);
            if (product == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<CategoriesList_VM>> GetCategoriesOfProduct(string stockCode)
        {
            List<CategoriesList_VM>? categoriesOfProduct = await (from cp in _c.ProductCategories
                                                                  join c in _c.Categories on cp.CategoryId equals c.Id
                                                                  join p in _c.Products on cp.ProductId equals p.Id

                                                                  where p.StockCode == stockCode
                                                                  group c by c.Id into groupedCategories
                                                                  select new CategoriesList_VM
                                                                  {
                                                                      Id = groupedCategories.Key,
                                                                      Description = groupedCategories.First().Description
                                                                  }).ToListAsync();
            if (categoriesOfProduct == null)
            {
                return null;
            }
            else
            {
                return categoriesOfProduct;
            }
        }

        public async Task<List<Dimention_VM>> GetDimentionsOfProduct(string stockCode, int colorId)
        {
            List<Dimention_VM>? dimentionsOfProduct = await (from p in _c.Products
                                                             join d in _c.Dimensions on p.DimensionId equals d.Id
                                                             where p.StockCode == stockCode && p.ColorId == colorId
                                                             group d by d.Id into groupedDimensions
                                                             select new Dimention_VM
                                                             {
                                                                 Id = groupedDimensions.Key,
                                                                 Description = groupedDimensions.First().Description
                                                             }).ToListAsync();
            if (dimentionsOfProduct == null)
            {
                return null;
            }
            else
            {
                return dimentionsOfProduct;
            }
        }
        public async Task<List<GetProductPhotoResponse>> GetProductPhotos(GetProductPhotoCommandModel model)
        {
            List<GetProductPhotoResponse> result = await (from p in _c.Products
                                                          join pp in _c.ProductPhotos on p.Id equals pp.ProductId
                                                          join ph in _c.Photos on pp.PhotoId equals ph.Id
                                                          where p.StockCode == model.StockCode && p.ColorId == model.ColorId
                                                          group new { ph.Url, ph.Id, pp.IsFirstPhoto } by new { p.StockCode, p.ColorId } into g
                                                          select new GetProductPhotoResponse
                                                          {
                                                              StockCode = g.Key.StockCode,
                                                              ColorId = g.Key.ColorId,
                                                              Photos = g.Select(x => new PhotoDetail
                                                              {
                                                                  Url = x.Url,
                                                                  Id = x.Id,
                                                                  IsFirstPhoto = x.IsFirstPhoto
                                                              }).Distinct().ToList(),
                                                          }).ToListAsync();

            return result;
        }

        public async Task<List<Color_VM>> GetColorsOfProduct(string stockCode, int colorId)
        {
            List<Color_VM>? ColorsOfProduct = await (from p in _c.Products
                                                     join d in _c.Dimensions on p.DimensionId equals d.Id
                                                     where p.StockCode == stockCode && p.ColorId == colorId
                                                     group d by d.Id into groupedDimensions
                                                     select new Color_VM
                                                     {
                                                         Id = groupedDimensions.Key,
                                                         Description = groupedDimensions.First().Description
                                                     }).ToListAsync();
            if (ColorsOfProduct == null)
            {
                return null;
            }
            else
            {
                return ColorsOfProduct;
            }
        }

        public async Task<bool> UploadProductPhotos(UploadProductPhotoCommandModel model)
        {
            using var transaction = _c.Database.BeginTransaction();
            try
            {
                List<Photo> photos = new List<Photo>();
                foreach (var url in model.Urls)
                {
                    Photo photo = new Photo();
                    photo.Url = url;
                    photos.Add(photo);

                }
                var response = await _ph.AddRangeAsync(photos);
                List<Photo> uploadedPhotos = new List<Photo>();
                foreach (var url in model.Urls)
                {
                    Photo? photo = await _c.Photos.FirstOrDefaultAsync(ph => ph.Url == url);
                    if (photo == null)
                    { continue; }

                    uploadedPhotos.Add(photo);

                }


                if (response)
                {
                    List<Product>? products = await _c.Products.Where(p => p.StockCode == model.StockCode && p.ColorId == model.ColorId).ToListAsync();
                    if (products != null)
                    {
                        List<ProductPhoto> productPhotos = new List<ProductPhoto>();
                        foreach (var product in products)
                        {
                            foreach (var photo in uploadedPhotos)
                            {
                                ProductPhoto newProductPhoto = new ProductPhoto();
                                newProductPhoto.ProductId = product.Id;
                                newProductPhoto.PhotoId = photo.Id;
                                productPhotos.Add(newProductPhoto);

                            }

                        }
                        if (productPhotos != null)
                        {
                            await _c.ProductPhotos.AddRangeAsync(productPhotos);
                            await _c.SaveChangesAsync();

                            await transaction.CommitAsync();
                            return true;
                        }
                        else
                        {
                            await transaction.RollbackAsync();
                            return false;
                        }
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                        return false;
                    }

                }
                else
                {
                    await transaction.RollbackAsync();
                    return false;
                }

                //dah asonra ilgili ürün kodu ve color code a ait tüm idleri çekicek 


                //daha sonra productsPhotos a kayıt edicek
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }

        }

        public async Task<bool> DeleteProductPhotoByPhotoId(DeleteProductPhotoByIdCommandModel model)
        {


            Photo? photo = await _c.Photos.FirstOrDefaultAsync(photo => photo.Id == model.PhotoId);
            if (photo != null)
            {
                var response = await _ph.RemoveAsync(photo.Id);
                return true;
            }
            else
            {
                return false;

            }



        }

        public async Task<bool> DeleteProductCard(ProductCard_DTO model)
        {
            List<Product>? products = await _c.Products.Where(p => p.ColorId == model.ColorId && p.StockCode == model.StockCode).ToListAsync();
            if (products != null && products.Count > 0)
            {
                var response = await _pw.RemoveRange(products);
                if (response)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateProductStockById(UpdateProductStockByIdComandModel model)
        {
            Product? product = await _c.Products.FirstOrDefaultAsync(p => p.Id == model.ProductId);
            if (product != null)
            {
                product.StockAmount = model.StockAmount;
                var response = await _pw.Update(product);
                if (response)
                {
                    return true;
                }
                else
                { return false; }


            }
            else
            { return false; }
        }

        public async Task<bool> UpdateFistPhotoOfCard(UpdateFistPhotoOfCardCommandModel model)
        {
            using var transaction = _c.Database.BeginTransaction(); // Veritabanı işlemi başlatılır

            try
            {
                //ürün kartına ait ürünler çekilir
                List<Product>? products = await _c.Products.Where(p => p.ColorId == model.ColorId && p.StockCode == model.StockCode).ToListAsync();

                //ara tablodaki veriler değiştirilir


                if (products != null && products.Count > 0)
                {
                    List<ProductPhoto> productPhotos = new List<ProductPhoto>();
                    foreach (var item in products)
                    {
                        ProductPhoto? productPhoto = await _c.ProductPhotos.FirstOrDefaultAsync(pp => pp.ProductId == item.Id && pp.PhotoId == model.PhotoId);
                        if (productPhoto != null)
                        {
                            productPhotos.Add(productPhoto);
                        }
                    }



                    //eğer daha önce ürün kartı içindeki ürünlerde herhangi bir ilk resim varsa bu değeri false yap 

                    List<ProductPhoto> productPhotos2 = new List<ProductPhoto>();
                    List<int> IdList = products.Select(p => p.Id).ToList();
                    foreach (var id in IdList)
                    {
                        List<ProductPhoto>? productPhotos3 = await _c.ProductPhotos.Where(pp => pp.ProductId == id).ToListAsync();
                        if (productPhotos3.Count > 0)
                        {
                            foreach (var item in productPhotos3)
                            {
                                productPhotos2.Add(item);
                            }

                        }
                    }

                    foreach (var productPhoto in productPhotos2)
                    {
                        if (productPhoto.IsFirstPhoto)
                        {
                            productPhoto.IsFirstPhoto = false;
                            _c.ProductPhotos.Update(productPhoto);
                            _c.SaveChanges();
                        }
                    }

                    //gelen ürün kartını güncelle

                    foreach (var item in productPhotos)
                    {
                        item.IsFirstPhoto = true;
                    }


                    foreach (var item in productPhotos)
                    {

                        _c.ProductPhotos.UpdateRange(productPhotos);
                        _c.SaveChanges();

                    }
                    await transaction.CommitAsync();
                    return true;
                }
                else
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }

        }

        public async Task<List<GetBasketProductsFilter_ResponseModel>> GetBasketProductsByFilter(GetBasketProductsFilter_CommandModel model)
        {
            IQueryable<Product> query = _c.Products.AsQueryable();

            if (model.Id != 0)
            {
                query = query.Where(p => p.Id == model.Id);
            }

            if (!string.IsNullOrEmpty(model.CartId))
            {
                query = query.Where(p => p.StockCode + "-" + p.ColorId == model.CartId);
            }

            if (!string.IsNullOrEmpty(model.Barcode))
            {
                query = query.Where(p => p.Barcode == model.Barcode);
            }

            if (!string.IsNullOrEmpty(model.StockCode))
            {
                query = query.Where(p => p.StockCode == model.StockCode);
            }

            if (!string.IsNullOrEmpty(model.Description))
            {
                query = query.Where(p => p.Description == model.Description);
            }

            // Burada query değişkeni, filtrelenmiş sorgu sonucunu içerecektir.
            // Şimdi sorgunuzu devam ettirebilir ve sonucu alabilirsiniz.

            List<GetBasketProductsFilter_ResponseModel> result = query.ToList().Select(p => new GetBasketProductsFilter_ResponseModel
            {
                Id = p.Id,
                PhotoUrl = _c.Photos.FirstOrDefault(ph => ph.Id == _c.ProductPhotos.FirstOrDefault(pp => pp.ProductId == p.Id && pp.IsFirstPhoto == true).PhotoId)?.Url,
                CardId = p.StockCode + "-" + p.ColorId.ToString(),
                StockCode = p.StockCode,
                Description = p.Description,
                StockAmount = p.StockAmount,
                Barcode = p.Barcode,
                NormalPrice = p.NormalPrice,
                DiscountedPrice = p.DiscountedPrice,
                ColorDescription = _c.Colors.FirstOrDefault(c => c.Id == p.ColorId)?.Description,
                DimensionDescription = _c.Dimensions.FirstOrDefault(c => c.Id == p.DimensionId)?.Description,
                
            }).ToList();

            return result;
        }

    }
}
