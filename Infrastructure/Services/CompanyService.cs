using System;
using System.Threading;
using System.Threading.Tasks;
using ContactManagement.ApplicationCore.Services;
using ContactManagement.ApplicationCore.Entities;
using ContactManagement.ApplicationCore.Repositories;
using System.Collections.Generic;

namespace ContactManagement.Infrastructure.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository) =>
            _companyRepository = companyRepository;

        public async ValueTask<long> CreateAsync(Company organization, CancellationToken cancellationToken = default)
        {
            _companyRepository.Add(organization);
            await _companyRepository.CommitAsync(cancellationToken);
            return organization.Id;
        }

        public async ValueTask DeleteIdAsync(long id, CancellationToken cancellationToken = default)
        {
            _companyRepository.RemoveById(id);
            await _companyRepository.CommitAsync(cancellationToken);
        }

        public async ValueTask<IEnumerable<Company>> GetAllAsync(CancellationToken cancellationToken = default) {
            return await _companyRepository.GetAllAsync(cancellationToken);
        }

        public async ValueTask<Company> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return await _companyRepository.FindByIdAsync(id, cancellationToken);
        }

        public ValueTask ModifyAsync(long companyId, Company company, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
