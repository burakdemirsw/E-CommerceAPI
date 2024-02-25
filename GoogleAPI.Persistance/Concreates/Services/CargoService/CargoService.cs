using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Entities.Cargo;
using GoogleAPI.Domain.Models.Cargo.ViewModel;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.Abstractions.IServices.ICargo;
using GooleAPI.Application.IRepositories;
using Microsoft.EntityFrameworkCore;


namespace GoogleAPI.Persistance.Concreates.Services.CargoService
{
    public class CargoService : ICargoService
    {

        private readonly GooleAPIDbContext _context;
        private readonly ICargoWriteRepository _cw;
        private readonly ICargoReadRepository _cr;


        private readonly string ErrorTextBase = "İstek Sırasında Hata Oluştu: ";

        public CargoService(
            GooleAPIDbContext context,
            ICargoWriteRepository cw,
            ICargoReadRepository cr

        )
        {
            _cw = cw;
            _cr = cr;

            _context = context;
        }
        public  async Task<bool> AddCargoFirm(CargoFirm cargo)
        {
            var response = await _cw.AddAsync(cargo);
            return response;

        }

        public  async Task<bool> DeleteCargoFirm(int cargoId)
        {
            CargoFirm cargo = await _cr.GetByIdAsync(cargoId, false);
            if (cargo == null)
            {
                return false;
            }

            bool response = _cw.Remove(cargo);
            return response;
        }

        public  async Task<CargoFirm> GetCargoFirmById(int cargoId)
        {
            CargoFirm cargo = await _cr.GetByIdAsync(cargoId, false);
            if (cargo == null)
            {
                return null;
            }
            return cargo;


        }

        public  async Task<List<CargoFirmList_VM>> GetCargoFirmList( )
        {
            List<CargoFirmList_VM> response =  _context.CargoFirms.ToList().Select(c => new CargoFirmList_VM
            {
                Id = c.Id,
                PhotoUrl = c.PhotoUrl,
                IsBPCActive = c.IsBPCActive,
                IsCCPCActive = c.IsCCPCActive,
                IsCPCActive = c.IsCPCActive,
                IsSPCActive = c.IsSPCActive,    
                IsActive = c.IsActive,
                Description = c.Description,
                CreatedDate = c.CreatedDate,
                UpdatedDate = c.UpdatedDate,
            }).ToList();


            return response;
        }

        public async Task<CargoFirm> GetFirstCargo( )
        {
            CargoFirm? cargo = await _cr.Table.FirstOrDefaultAsync(cf=>cf.IsActive == true);
            if (cargo == null)
            {
                throw new Exception("Aktif Kargo Yok");
            }
            return cargo;
        }

        public async Task<bool> SetFirstCargoFirm(int cargoId)
        {
            CargoFirm _cargo = await _cr.GetByIdAsync(cargoId, false);
            if (_cargo == null)
            {
                return false;
            }
            _cargo.IsActive = true;
            await _cw.Update(_cargo);
            List<CargoFirm> _cargos = await _context.CargoFirms.Where(c => c.Id != cargoId).ToListAsync();
            
            foreach (var c in _cargos)
            {
                c.IsActive = false;
                await _cw.Update(c);
            }

            return true;
        }

        public async Task<bool> UpdateCargoFirm(CargoFirm cargo)
        {
            CargoFirm _cargo = await _cr.GetByIdAsync(cargo.Id, false);
            if (_cargo == null)
            {
                return false;
            }

            // Update all properties of _cargo with values from cargo
            _cargo.Description = cargo.Description;
            _cargo.CargoPaymentDescription = cargo.CargoPaymentDescription;
            _cargo.PhotoUrl = cargo.PhotoUrl;
            _cargo.IsActive = cargo.IsActive;

            _cargo.IsCPCActive = cargo.IsCPCActive;
            _cargo.CPC_Price = cargo.CPC_Price;
            _cargo.CPC_LowerPriceLimit = cargo.CPC_LowerPriceLimit;
            _cargo.CPC_UpperPriceLimit = cargo.CPC_UpperPriceLimit;

            _cargo.IsCCPCActive = cargo.IsCCPCActive;
            _cargo.CCPC_Price = cargo.CCPC_Price;
            _cargo.CCPC_LowerPriceLimit = cargo.CCPC_LowerPriceLimit;
            _cargo.CCPC_UpperPriceLimit = cargo.CCPC_UpperPriceLimit;

            _cargo.IsBPCActive = cargo.IsBPCActive;
            _cargo.BPC_Price = cargo.BPC_Price;
            _cargo.BPC_LowerPriceLimit = cargo.BPC_LowerPriceLimit;
            _cargo.BPC_UpperPriceLimit = cargo.BPC_UpperPriceLimit;

            _cargo.IsSPCActive = cargo.IsSPCActive;
            _cargo.SPC_Price = cargo.SPC_Price;
            _cargo.SPC_LowerPriceLimit = cargo.SPC_LowerPriceLimit;
            _cargo.SPC_UpperPriceLimit = cargo.SPC_UpperPriceLimit;

            _cargo.UserName = cargo.UserName;
            _cargo.CustomerCode = cargo.CustomerCode;
            _cargo.Password = cargo.Password;
            _cargo.Currency = cargo.Currency;
            _cargo.isZPLBarcode = cargo.isZPLBarcode;
            _cargo.isDifferentBarcode = cargo.isDifferentBarcode;
            _cargo.ApiKey = cargo.ApiKey;
            _cargo.ApiSecretKey = cargo.ApiSecretKey;

            _cargo.StockCode = cargo.StockCode; 

            var response = await _cw.Update(_cargo);
            return response;
        }


       public async Task<bool> UpdateCargoFirmProperties(int cargoFirmId , int state )
        {
            CargoFirm? cargoFirm  = await _cr.GetByIdAsync(cargoFirmId);
            if (state == 1) 
            {
                cargoFirm.IsActive = !cargoFirm.IsActive;
            }
            else if (state == 2)
            {
                cargoFirm.IsCPCActive = !cargoFirm.IsCPCActive;
            }
            else if (state == 3)
            {
                cargoFirm.IsCCPCActive = !cargoFirm.IsCCPCActive;
            }
            else if (state == 4)
            {
                cargoFirm.IsBPCActive = !cargoFirm.IsBPCActive;
            }
            else if (state == 5)
            {
                cargoFirm.IsSPCActive = !cargoFirm.IsSPCActive;
            }

            var response  = await _cw.Update(cargoFirm);

            return response;
        }
    }
}
