using GoogleAPI.Domain.Entities;
using GoogleAPI.Domain.Entities.Cargo;
using GoogleAPI.Persistance.Contexts;
using GoogleAPI.Persistance.Repositories;

namespace GooleAPI.Application.IRepositories
{
    public class CargoWriteRepository : WriteRepository<CargoFirm>, ICargoWriteRepository
    {
        public CargoWriteRepository(GooleAPIDbContext context) : base(context) { }
    }
}
