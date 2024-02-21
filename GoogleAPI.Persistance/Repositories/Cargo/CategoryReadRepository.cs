using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Entities.Cargo;
using GoogleAPI.Persistance.Contexts;
using GoogleAPI.Persistance.Repositories;
namespace GooleAPI.Application.IRepositories
{
    public class CargoReadRepository : ReadRepository<CargoFirm>, ICargoReadRepository
    {
        public CargoReadRepository(GooleAPIDbContext context) : base(context) { }
    }
}
