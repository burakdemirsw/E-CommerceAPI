using GoogleAPI.Domain.Models.Supplier.ViewModel;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.Abstractions.IServices.ISupplier;
using GooleAPI.Application.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GoogleAPI.Persistance.Concreates.Services.Supplier
{
    public class SupplierService : ISupplierService
    {
        private readonly GooleAPIDbContext _context;
        private readonly ISupplierWriteRepository _sw;
        private readonly ISupplierReadRepository _sr;

        private readonly string ErrorTextBase = "İstek Sırasında Hata Oluştu: ";

        public SupplierService(GooleAPIDbContext context, ISupplierWriteRepository cw, ISupplierReadRepository cr)
        {
            _context = context;
            _sw = cw;
            _sr = cr;
        }



        public async Task<bool> AddSupplier(Supplier_VM Supplier)
        {
            try
            {
                Domain.Entities.Supplier newSupplier = new Domain.Entities.Supplier
                {
                    Description = Supplier.Description,

                };

                await _sw.AddAsync(newSupplier);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"AddSupplier method failed: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteSupplier(int id)
        {
            try
            {
                var Supplier = await _sr.GetByIdAsync(id);
                if (Supplier == null)
                {
                    return false;
                }

                bool response = _sw.Remove(Supplier);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"DeleteSupplier method failed: {ex.Message}", ex);
            }
        }

        public async Task<List<Supplier_VM>> GetSupplierById(int id)
        {
            try
            {
                List<Domain.Entities.Supplier> suppliers = new List<Domain.Entities.Supplier>();

                if (id == 0)
                {
                    suppliers = _sr.GetAll().ToList();
                }
                else
                {
                    Domain.Entities.Supplier supplier = await _sr.GetByIdAsync(id, true);
                    if (supplier != null)
                    {
                        suppliers.Add(supplier);
                    }
                }

                List<Supplier_VM> _suppliers = suppliers.Select(c => new Supplier_VM
                {
                    Id = c.Id,
                    Description = c.Description
                }).ToList();

                return _suppliers;
            }
            catch (Exception ex)
            {

                throw new Exception($"GetColors method failed: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateSupplier(Supplier_VM model)
        {
            try
            {
                Domain.Entities.Supplier? supplier = await _sr.Table.FirstOrDefaultAsync(b => b.Id == model.Id);

                supplier.Description = model.Description;
                var response = await _sw.Update(supplier);
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception($"AddSupplier method failed: {ex.Message}", ex);
            }
        }
    }
}
