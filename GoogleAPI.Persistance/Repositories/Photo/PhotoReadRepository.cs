using GoogleAPI.Domain.Entities;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.IRepositories;

namespace GoogleAPI.Persistance.Repositories
{
    public class PhotoReadRepository : ReadRepository<Photo>, IPhotoReadRepository
    {
        public PhotoReadRepository(GooleAPIDbContext context) : base(context) { }
    }
}
