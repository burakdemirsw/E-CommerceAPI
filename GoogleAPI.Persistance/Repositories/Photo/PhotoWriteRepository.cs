using GoogleAPI.Domain.Entities;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.IRepositories;

namespace GoogleAPI.Persistance.Repositories
{
    public class PhotoWriteRepository : WriteRepository<Photo>, IPhotoWriteRepository
    {
        public PhotoWriteRepository(GooleAPIDbContext context) : base(context) { }
    }
}
