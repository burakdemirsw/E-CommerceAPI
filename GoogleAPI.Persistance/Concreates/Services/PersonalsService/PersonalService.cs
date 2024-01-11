using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Models.Personal.ViewModel;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.Abstractions.IServices.IPersonal;
using GooleAPI.Application.IRepositories;

namespace GoogleAPI.Persistance.Concreates.Services.PersonalsService
{
    public class PersonalService : IPersonalService
    {
        private readonly GooleAPIDbContext _context;
        private readonly IPersonalWriteRepository _cw;
        private readonly IPersonalReadRepository _cr;

        private readonly string ErrorTextBase = "İstek Sırasında Hata Oluştu: ";

        public PersonalService(GooleAPIDbContext context, IPersonalWriteRepository cw, IPersonalReadRepository cr)
        {
            _context = context;
            _cw = cw;
            _cr = cr;
        }

        public async Task<List<Personal_VM>> GetPersonals(int id)
        {
            try
            {
                List<Personal> personals = new List<Personal>();

                if (id == 0)
                {
                    personals = _cr.GetAll().ToList();
                }
                else
                {
                    Personal personal = await _cr.GetByIdAsync(id, true);
                    if (personal != null)
                    {
                        personals.Add(personal);
                    }
                }

                List<Personal_VM> _personals = personals.Select(p => new Personal_VM
                {
                    Id = p.Id,
                    Description = p.Description,
                    Email = p.Email,
                    PhoneNumber = p.PhoneNumber,
                    PhotoUrl = p.PhotoUrl
                }).ToList();

                return _personals;
            }
            catch (Exception ex)
            {
                throw new Exception($"GetPersonals method failed: {ex.Message}", ex);
            }
        }

        public async Task<bool> AddPersonal(Personal_VM model)
        {
            try
            {
                Personal personal = new Personal
                {
                    Description = model.Description,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    PhotoUrl = model.PhotoUrl
                };

                await _cw.AddAsync(personal);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"AddPersonal method failed: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdatePersonal(Personal_VM model)
        {
            try
            {
                Personal? personal = _cr.Table.FirstOrDefault(p => p.Id == model.Id);

                if (personal != null)
                {
                    personal.Description = model.Description;
                    personal.PhoneNumber = model.PhoneNumber;
                    personal.Email = model.Email;
                    personal.PhotoUrl = model.PhotoUrl;


                    var response = await _cw.Update(personal);

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


        public async Task<bool> DeletePersonal(int id)
        {
            try
            {
                Personal personal = await _cr.GetByIdAsync(id, false);
                if (personal == null)
                {
                    return false;
                }

                bool response = _cw.Remove(personal);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"DeletePersonal method failed: {ex.Message}", ex);
            }
        }
    }
}
