using ContactManagement.ApplicationCore.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ContactManagement.ApplicationCore.Services
{
    public interface IAddressService
    {
        ValueTask<long> CreateAsync(long companyId, Address address, CancellationToken cancellationToken = default);
        ValueTask ModifyAsync(long addressId, Address address, CancellationToken cancellationToken = default);
    }
}
