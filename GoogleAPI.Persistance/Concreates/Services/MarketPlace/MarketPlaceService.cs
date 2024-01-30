using GoogleAPI.Domain.Models.MarketPlace.ViewModel;
using GoogleAPI.Domain.Models.MarketPlace.ViewModel;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.Abstractions.IServices.IMarketPlace;
using GooleAPI.Application.Abstractions.IServices.IMarketPlace;
using GooleAPI.Application.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAPI.Persistance.Concreates.Services.MarketPlace
{
    public class MarketPlaceService : IMarketPlaceService
    {
        private readonly GooleAPIDbContext _context;
        private readonly IMarketPlaceWriteRepository _mw;
        private readonly IMarketPlaceReadRepository _mr;

        private readonly string ErrorTextBase = "İstek Sırasında Hata Oluştu: ";

        public MarketPlaceService(GooleAPIDbContext context, IMarketPlaceWriteRepository mw, IMarketPlaceReadRepository mr)
        {
            _context = context;
            _mw = mw;
            _mr = mr;
        }



        public async Task<bool> AddMarketPlace(MarketPlace_VM MarketPlace)
        {
            try
            {
                Domain.Entities.MarketPlace newMarketPlace = new Domain.Entities.MarketPlace
                {
                    Description = MarketPlace.Description,
                    ApiKey = MarketPlace.ApiKey,
                    ApiSecretKey = MarketPlace.ApiSecretKey,
                    SupplierId = MarketPlace.SupplierId,
                    
                    CreatedDate = DateTime.Now,

                };

                await _mw.AddAsync(newMarketPlace);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"AddMarketPlace method failed: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteMarketPlace(int id)
        {
            try
            {
                var MarketPlace = await _mr.GetByIdAsync(id);
                if (MarketPlace == null)
                {
                    return false;
                }

                bool response = _mw.Remove(MarketPlace);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"DeleteMarketPlace method failed: {ex.Message}", ex);
            }
        }

        public Task<List<MarketPlace_VM>> GetMarketPlaceById(int MarketPlaceId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateMarketPlace(MarketPlace_VM model)
        {
            try
            {
                Domain.Entities.MarketPlace? MarketPlace = await _mr.Table.FirstOrDefaultAsync(b => b.Id == model.Id);

                MarketPlace.Description = model.Description;
                var response = await _mw.Update(MarketPlace);
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception($"AddMarketPlace method failed: {ex.Message}", ex);
            }
        }
    }
}
