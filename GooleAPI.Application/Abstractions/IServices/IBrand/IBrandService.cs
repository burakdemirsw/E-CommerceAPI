using GoogleAPI.Domain.Models.Brand.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GooleAPI.Application.Abstractions.IServices.IBrand
{
    public interface IBrandService
    {
        Task<List<Brand_VM>> GetBrandById(int brandId);
        Task<bool> AddBrand(Brand_VM brand); 
        Task<bool> UpdateBrand(Brand_VM brand); 

        Task<bool> DeleteBrand(int id);
    }
}
