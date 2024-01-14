using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Models.Product.ViewModel;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAPI.API.Controllers
{
    [Route("api/dimensions")]
    [ApiController]
    //[Authorize(AuthenticationSchemes ="Admin")]
    public class DimensionsController : ControllerBase
    {
        private readonly GooleAPIDbContext _context;
        private readonly IDimensionWriteRepository _cw;
        private readonly IDimensionReadRepository _cr;

        private readonly string ErrorTextBase = "Ýstek Sýrasýnda Hata Oluþtu: ";
        public DimensionsController(
           GooleAPIDbContext context, IDimensionWriteRepository cw, IDimensionReadRepository cr
        )
        {
            _cw = cw;
            _cr = cr;
            _context = context;
        }



        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<Dimention_VM>>> GetDimensions(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    List<Dimension> Dimensions = _cr.GetAll().ToList();
                    List<Dimention_VM> _Dimensions = Dimensions.Select(c => new Dimention_VM
                    {
                        Id = c.Id,
                        Description = c.Description
                    }).ToList();

                    return _Dimensions;
                }
                else
                {

                    List<Dimension> Dimensions = new List<Dimension>();
                    Dimension Dimension = await _cr.GetByIdAsync(Id, true);
                    Dimensions.Add(Dimension);
                    List<Dimention_VM> _Dimensions = Dimensions.Select(c => new Dimention_VM
                    {
                        Id = c.Id,
                        Description = c.Description
                    }).ToList();

                    return _Dimensions;
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ErrorTextBase + ex.Message);
            }
        }


        [HttpPost("Add")]
        public async Task<ActionResult<Dimension>> AddDimension(Dimention_VM model)
        {
            try
            {
                Dimension Dimension = new();
                Dimension.Description = model.Description;
                await _cw.AddAsync(Dimension);

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorTextBase + ex.Message);
            }
        }

        [HttpPost("update")]
        public async Task<ActionResult<bool>> UpdateDimension(Dimention_VM model)
        {
            try
            {
                Dimension? dimension = _cw.Table.FirstOrDefault(p => p.Id == model.Id);

                if (dimension != null)
                {
                    dimension.Description = model.Description;




                    var response = await _cw.Update(dimension);

                    return response;

                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                throw new Exception($"AddPersonal method failed: {ex.Message}", ex);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteDimension(int id)
        {
            try
            {
                Dimension Dimension = await _cr.GetByIdAsync(id, false);
                if (Dimension == null)
                {
                    return NotFound();
                }

                bool response = _cw.Remove(Dimension);
                if (response)
                {
                    return Ok(true);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorTextBase + ex.Message);
            }
        }


    }
}