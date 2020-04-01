using System.Threading;
using System.Threading.Tasks;
using ContactManagement.ApplicationCore.Services;
using ContactManagement.ApplicationCore.Entities;
using ContactManagement.ApplicationCore.Repositories;

namespace ContactManagement.Infrastructure.Services
{
    public class AddressService : IAddressService
    {
        public ValueTask<long> CreateAsync(Address address, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask<long> CreateAsync(long companyId, Address address, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public ValueTask ModifyAsync(long addressId, Address address, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
