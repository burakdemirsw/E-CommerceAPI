using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Models.Product.ViewModel;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.Abstractions.IServices.IColor;
using GooleAPI.Application.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GoogleAPI.Persistance.Concreates.Services.ColorsService
{
    public class ColorService : IColorService
    {
        private readonly GooleAPIDbContext _context;
        private readonly IColorWriteRepository _cw;
        private readonly IColorReadRepository _cr;

        private readonly string ErrorTextBase = "İstek Sırasında Hata Oluştu: ";

        public ColorService(GooleAPIDbContext context, IColorWriteRepository cw, IColorReadRepository cr)
        {
            _context = context;
            _cw = cw;
            _cr = cr;
        }

        public async Task<List<Color_VM>> GetColors(int id)
        {
            try
            {
                List<Color> colors = new List<Color>();

                if (id == 0)
                {
                    colors = _cr.GetAll().ToList();
                }
                else
                {
                    Color color = await _cr.GetByIdAsync(id, true);
                    if (color != null)
                    {
                        colors.Add(color);
                    }
                }

                List<Color_VM> _colors = colors.Select(c => new Color_VM
                {
                    Id = c.Id,
                    Description = c.Description
                }).ToList();

                return _colors;
            }
            catch (Exception ex)
            {

                throw new Exception($"GetColors method failed: {ex.Message}", ex);
            }
        }

        public async Task<bool> AddColor(Color_VM model)
        {
            try
            {
                Color color = new Color
                {
                    Description = model.Description
                };

                await _cw.AddAsync(color);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"AddColor method failed: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateColor(Color_VM model)
        {
            try
            {
                Color? color = _cr.Table.FirstOrDefault(p => p.Id == model.Id);

                if (color != null)
                {
                    color.Description = model.Description == null ? "" : model.Description;

                    var response = await _cw.Update(color);

                    return response;

                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                throw new Exception($"UpdateColor method failed: {ex.Message}", ex);
            }
        }



        public async Task<bool> DeleteColor(int id)
        {
            try
            {
                Color? color = await _cr.Table.FirstOrDefaultAsync(c => c.Id == id);
                if (color == null)
                {
                    return false;
                }

                bool response = _cw.Remove(color);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"DeleteColor method failed: {ex.Message}", ex);
            }
        }
    }
}
