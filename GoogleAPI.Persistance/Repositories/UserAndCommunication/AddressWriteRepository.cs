using GoogleAPI.Domain.Entities.User;
using GoogleAPI.Persistance.Contexts;
using GooleAPI.Application.IRepositories.UserAndCommunication;

namespace GoogleAPI.Persistance.Repositories.UserAndCommunication
{
    public class AddressWriteRepository : WriteRepository<ShippingAddress>, IAddressWriteRepository
    {
        public AddressWriteRepository(GooleAPIDbContext context) : base(context) { }
    }
}
