using GoogleAPI.Domain.Models.Supplier.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GooleAPI.Application.Abstractions.IServices.ISupplier
{
    public interface ISupplierService
    {
        Task<List<Supplier_VM>> GetSupplierById(int SupplierId);
        Task<bool> AddSupplier(Supplier_VM Supplier); 
        Task<bool> UpdateSupplier(Supplier_VM Supplier); 

        Task<bool> DeleteSupplier(int id);
    }
}
