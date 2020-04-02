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
        private readonly IAddressRepository _addressRepository;

        public CompanyService(ICompanyRepository companyRepository, IAddressRepository addressRepository)
        {
            _companyRepository = companyRepository;
            _addressRepository = addressRepository;
        }

        public async ValueTask<long> CreateAsync(Company organization, CancellationToken cancellationToken = default)
        {
            // fix. SqlException: Cannot insert explicit value for identity column in table 'Address' when IDENTITY_INSERT is set to OFF.
            //  * assign to 0 otherwise ValueGeneratedOnAdd() is not working
            organization.Id = 0L;
            organization.MainAddressId = 0L;
            organization.MainAddress.Id = 0L;
            _addressRepository.Add(organization.MainAddress);
            await _addressRepository.CommitAsync(cancellationToken);
            
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
            _companyRepository.AddInclude("MainAddress");
            _companyRepository.AddInclude("AddressRoles.Address");
            return await _companyRepository.GetAllAsync(cancellationToken);
        }

        public async ValueTask<Company> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            _companyRepository.AddInclude("MainAddress");
            _companyRepository.AddInclude("AddressRoles.Address");
            return await _companyRepository.FindByIdAsync(id, cancellationToken);
        }

        public async ValueTask ModifyAsync(long companyId, Company company, CancellationToken cancellationToken = default)
        {
            var prevCompany = await GetByIdAsync(companyId, cancellationToken);
            var prevMainAddress = await _addressRepository.FindByIdAsync(company.MainAddressId, cancellationToken);
            //TODO: validation here  + dynamic mapping
            prevCompany.Name = company.Name;
            prevCompany.Vat = company.Vat;
            prevMainAddress.City = company.MainAddress.City;
            prevMainAddress.ZipCode = company.MainAddress.ZipCode;
            prevMainAddress.Description = company.MainAddress.Description;
            // update 
            _companyRepository.Update(prevCompany);
            _addressRepository.Update(prevMainAddress);
            await _companyRepository.CommitAsync(cancellationToken);
        }
    }
}
