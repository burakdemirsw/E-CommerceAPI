using GoogleAPI.Domain.Models.Product.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooleAPI.Application.Abstractions.IServices.IColor
{
    public interface IColorService
    {
        Task<List<Color_VM>> GetColors(int id);
        Task<bool> AddColor(Color_VM model);
        Task<bool> UpdateColor(Color_VM model);
        Task<bool> DeleteColor(int id);
    }
}
