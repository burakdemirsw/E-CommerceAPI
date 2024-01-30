using GoogleAPI.Domain.Entities;
using GoogleAPI.Persistance.Contexts;
using GoogleAPI.Persistance.Repositories;
namespace GooleAPI.Application.IRepositories
{
    public class MarketPlaceReadRepository : ReadRepository<MarketPlace>, IMarketPlaceReadRepository
    {
        public MarketPlaceReadRepository(GooleAPIDbContext context) : base(context) { }
    }
}
