using GoogleAPI.Domain.Models.Personal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooleAPI.Application.Abstractions.IServices.IPersonal
{
    public interface IPersonalService
    {
        Task<List<Personal_VM>> GetPersonals(int id);
        Task<bool> AddPersonal(Personal_VM model);
        Task<bool> DeletePersonal(int id);
        Task<bool> UpdatePersonal(Personal_VM model);
    }
}
