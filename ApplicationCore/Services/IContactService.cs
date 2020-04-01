using ContactManagement.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContactManagement.ApplicationCore.Services
{
    public interface IContactService
    {
        ValueTask<long> CreateAsync(Contact contact, CancellationToken cancellationToken = default);
        ValueTask ModifyAsync(long contactId, Contact contact, CancellationToken cancellationToken = default);
        ValueTask DeleteByIdAsync(long id, CancellationToken cancellationToken = default);
        ValueTask<IEnumerable<Contact>> GetAllAsync(CancellationToken cancellationToken = default);
        ValueTask<Contact> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    }
}
