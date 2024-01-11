using GoogleAPI.Domain.Entities;
using GoogleAPI.Persistance.Contexts;
using GoogleAPI.Persistance.Repositories;
namespace GooleAPI.Application.IRepositories
{
    public class PersonalReadRepository : ReadRepository<Personal>, IPersonalReadRepository
    {
        public PersonalReadRepository(GooleAPIDbContext context) : base(context) { }
    }
}
