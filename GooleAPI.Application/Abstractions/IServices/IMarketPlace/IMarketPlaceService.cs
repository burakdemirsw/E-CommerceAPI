using GoogleAPI.Domain.Models.MarketPlace.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooleAPI.Application.Abstractions.IServices.IMarketPlace
{
    public interface IMarketPlaceService
    {
        Task<List<MarketPlace_VM>> GetMarketPlaceById(int MarketPlaceId);
        Task<bool> AddMarketPlace(MarketPlace_VM MarketPlace);
        Task<bool> UpdateMarketPlace(MarketPlace_VM MarketPlace);

        Task<bool> DeleteMarketPlace(int id);
    }
}
