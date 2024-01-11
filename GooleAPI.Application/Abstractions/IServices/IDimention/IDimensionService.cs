using GoogleAPI.Domain.Models.Product.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooleAPI.Application.Abstractions.IServices.IDimention
{
    public interface IDimensionService
    {
        Task<List<Dimention_VM>> GetDimensions(int id);
        Task<bool> AddDimension(Dimention_VM model);
        Task<bool> DeleteDimension(int id);
    }
}
