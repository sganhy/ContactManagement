using ContactManagement.ApplicationCore.Entities;
using ContactManagement.ApplicationCore.Repositories;

namespace ContactManagement.Infrastructure.Data
{
    public class AddressRepository : DbRepository<Address>, IAddressRepository
    {
        public AddressRepository(ContactManagementDbContext context) : base(context)
        {
        }
    }
}
