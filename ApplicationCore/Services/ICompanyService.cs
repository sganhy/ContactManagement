using ContactManagement.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContactManagement.ApplicationCore.Services
{
    public interface ICompanyService
    {
        ValueTask<long> CreateAsync(Company organization, CancellationToken cancellationToken = default);
        ValueTask ModifyAsync(long companyId, Company company, CancellationToken cancellationToken = default);
        ValueTask DeleteIdAsync(long id, CancellationToken cancellationToken = default);
        ValueTask<IEnumerable<Company>> GetAllAsync(CancellationToken cancellationToken = default);
        ValueTask<Company> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    }
}
