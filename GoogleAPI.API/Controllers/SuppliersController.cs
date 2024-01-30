using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Models.Supplier.ViewModel;
using GooleAPI.Application.Abstractions.IServices.ISupplier;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _SupplierService;

        public SuppliersController(ISupplierService SupplierService)
        {
            _SupplierService = SupplierService;
        }

        [HttpGet("Get/{SupplierId}")]
        public async Task<ActionResult<IEnumerable<Supplier_VM>>> GetCategories(int SupplierId)
        {
            try
            {
                List<Supplier_VM> Suppliers = await _SupplierService.GetSupplierById(SupplierId);
                return Suppliers;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Supplier>> AddSupplier(Supplier_VM Supplier)
        {
            try
            {
                bool response = await _SupplierService.AddSupplier(Supplier);

                if (response)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("Supplier could not be added.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Update")]
        public async Task<ActionResult<Supplier>> AddUpdate(Supplier_VM Supplier)
        {
            try
            {
                bool response = await _SupplierService.UpdateSupplier(Supplier);

                if (response)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("Supplier could not be updated.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            try
            {
                bool response = await _SupplierService.DeleteSupplier(id);

                if (response)
                {
                    return Ok(true);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
