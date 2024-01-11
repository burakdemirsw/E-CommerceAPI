using GoogleAPI.Domain.Entities.User;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.IRepositories.UserAndCommunication;

namespace GoogleAPI.Persistance.Repositories.UserAndCommunication
{
    public class AddressReadRepository : ReadRepository<ShippingAddress>, IAddressReadRepository
    {
        public AddressReadRepository(GooleAPIDbContext context) : base(context) { }
    }
}
