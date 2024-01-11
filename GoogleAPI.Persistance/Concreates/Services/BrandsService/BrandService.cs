using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Models.Brand.ViewModel;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.Abstractions.IServices.IBrand;
using GooleAPI.Application.IRepositories;
using Microsoft.EntityFrameworkCore;


namespace GoogleAPI.Persistance.Services.BrandsService
{
    public class BrandService : IBrandService
    {
        private readonly GooleAPIDbContext _context;
        private readonly IBrandWriteRepository _cw;
        private readonly IBrandReadRepository _cr;

        private readonly string ErrorTextBase = "İstek Sırasında Hata Oluştu: ";

        public BrandService(GooleAPIDbContext context, IBrandWriteRepository cw, IBrandReadRepository cr)
        {
            _context = context;
            _cw = cw;
            _cr = cr;
        }

        public async Task<List<Brand_VM>> GetBrandById(int brandId)
        {
            try
            {
                var query = $"exec GetBrandById '{brandId}'";
                if (brandId == 0)
                {
                    query = $"exec GetBrandById ''";
                }

                return await _context.Brand_VM.FromSqlRaw(query).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"GetBrandById method failed: {ex.Message}", ex);
            }
        }

        public async Task<bool> AddBrand(Brand_VM brand)
        {
            try
            {
                Brand newBrand = new Brand
                {
                    Description = brand.Description,
                    PhotoUrl = brand.PhotoUrl
                };

                await _cw.AddAsync(newBrand);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"AddBrand method failed: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteBrand(int id)
        {
            try
            {
                var brand = await _cr.GetByIdAsync(id);
                if (brand == null)
                {
                    return false;
                }

                bool response = _cw.Remove(brand);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"DeleteBrand method failed: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateBrand(Brand_VM model)
        {
            try
            {
                Brand? brand = await _cr.Table.FirstOrDefaultAsync(b => b.Id == model.Id);
                brand.PhotoUrl = model.PhotoUrl;
                brand.Description = model.Description;
                var response = await _cw.Update(brand);
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception($"AddBrand method failed: {ex.Message}", ex);
            }
        }
    }
}
