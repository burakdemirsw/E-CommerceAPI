using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Models.Product.ViewModel;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.Abstractions.IServices.IDimention;
using GooleAPI.Application.IRepositories;

namespace GoogleAPI.Persistance.Concreates.Services.DimensionsService
{
    public class DimensionService : IDimensionService
    {
        private readonly IDimensionWriteRepository _cw;
        private readonly IDimensionReadRepository _cr;
        public DimensionService( IDimensionWriteRepository cw, IDimensionReadRepository cr)
        {
            
            _cw = cw;
            _cr = cr;
        }

        public async Task<List<Dimention_VM>> GetDimensions(int id)
        {
            try
            {
                List<Domain.Entities.Dimension> dimensions = new List<Domain.Entities.Dimension>();

                if (id == 0)
                {
                    dimensions = _cr.GetAll().ToList();
                }
                else
                {
                    Domain.Entities.Dimension dimension = await _cr.GetByIdAsync(id, true);
                    if (dimension != null)
                    {
                        dimensions.Add(dimension);
                    }
                }

                List<Dimention_VM> _dimensions = dimensions.Select(d => new Dimention_VM
                {
                    Id = d.Id,
                    Description = d.Description
                }).ToList();

                return _dimensions;
            }
            catch (Exception ex)
            {
                throw new Exception($"GetDimensions method failed: {ex.Message}", ex);
            }
        }

        public async Task<bool> AddDimension(Dimention_VM model)
        {
            try
            {
                Domain.Entities.Dimension dimension = new Domain.Entities.Dimension
                {
                    Description = model.Description
                };

                await _cw.AddAsync(dimension);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"AddDimension method failed: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteDimension(int id)
        {
            try
            {
                Domain.Entities.Dimension dimension = await _cr.GetByIdAsync(id, false);
                if (dimension == null)
                {
                    return false;
                }

                bool response = _cw.Remove(dimension);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"DeleteDimension method failed: {ex.Message}", ex);
            }
        }
    }
}
