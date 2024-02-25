using GoogleAPI.Domain.Entities.Cargo;
using GoogleAPI.Domain.Models.Cargo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooleAPI.Application.Abstractions.IServices.ICargo
{
    public interface ICargoService
    {
        Task<bool> AddCargoFirm(CargoFirm cargo );
        Task<bool> UpdateCargoFirm(CargoFirm cargo);
        Task<bool> DeleteCargoFirm(int cargoId );
        Task<List<CargoFirmList_VM>> GetCargoFirmList( );
        Task<CargoFirm> GetCargoFirmById(int cargoId);
        Task<bool> SetFirstCargoFirm(int cargoId);
        Task<bool> UpdateCargoFirmProperties(int cargoFirmId, int state);
        Task<CargoFirm> GetFirstCargo();
    }
   
}
