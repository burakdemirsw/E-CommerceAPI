using GoogleAPI.Domain.Entities;
using GoogleAPI.Persistance.Contexts;
using GoogleAPI.Persistance.Repositories;
namespace GooleAPI.Application.IRepositories
{
    public class PersonalWriteRepository : WriteRepository<Personal>, IPersonalWriteRepository
    {
        public PersonalWriteRepository(GooleAPIDbContext context) : base(context) { }
    }
}
