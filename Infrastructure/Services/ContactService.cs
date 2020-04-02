using System.Threading;
using System.Threading.Tasks;
using ContactManagement.ApplicationCore.Services;
using ContactManagement.ApplicationCore.Entities;
using ContactManagement.ApplicationCore.Repositories;
using System.Collections.Generic;

namespace ContactManagement.Infrastructure.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IContactRoleRepository _contactRoleRepository;
        private readonly IAddressRepository _addressRepository;

        public ContactService(IContactRepository contactRepository, IContactRoleRepository contactRoleRepository, IAddressRepository addressRepository)
        {
            _contactRepository = contactRepository;
            _contactRoleRepository = contactRoleRepository;
            _addressRepository = addressRepository;
        }

        public async ValueTask<long> CreateAsync(Contact contact, CancellationToken cancellationToken = default)
        {
            // fix. SqlException: Cannot insert explicit value for identity column in table 'Address' when IDENTITY_INSERT is set to OFF.
            //  * assign to 0 otherwise ValueGeneratedOnAdd() is not working
            contact.Id = 0L;
            contact.MainAddressId = 0L;
            contact.MainAddress.Id = 0L;
            _addressRepository.Add(contact.MainAddress);
            await _addressRepository.CommitAsync(cancellationToken);

            _contactRepository.Add(contact);
            await _contactRepository.CommitAsync(cancellationToken);

            return contact.Id;
        }

        public async ValueTask DeleteByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var contact = await GetByIdAsync(id,cancellationToken);
            // not found 
            if (contact == null) return;
            foreach (var contactRole in contact.ContactRoles)
            {
                _contactRoleRepository.Remove(contactRole);
            }
            await _contactRoleRepository.CommitAsync(cancellationToken); 
            _contactRepository.Remove(contact);
            await _contactRepository.CommitAsync(cancellationToken);
        }

        public async ValueTask ModifyAsync(long contactId, Contact contact, CancellationToken cancellationToken = default)
        {
            var prevContact = await GetByIdAsync(contactId, cancellationToken);
            var prevMainAddress = await _addressRepository.FindByIdAsync(contact.MainAddressId, cancellationToken);
            //TODO: validation here  + dynamic mapping
            prevContact.FirstName = contact.FirstName;
            prevContact.LastName = contact.LastName;
            prevContact.PhoneNumber = contact.PhoneNumber;
            prevContact.Vat = contact.Vat;
            //
            prevMainAddress.City = contact.MainAddress.City;
            prevMainAddress.ZipCode = contact.MainAddress.ZipCode;
            prevMainAddress.Description = contact.MainAddress.Description;
            // update 
            _contactRepository.Update(prevContact);
            _addressRepository.Update(prevMainAddress);
            await _contactRepository.CommitAsync(cancellationToken);
        }

        public async ValueTask<IEnumerable<Contact>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            _contactRepository.AddInclude("MainAddress");
            _contactRepository.AddInclude("ContactRoles.Organization");
            return await _contactRepository.GetAllAsync(cancellationToken);
        }

        

        public async ValueTask<Contact> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            _contactRepository.AddInclude("MainAddress");
            _contactRepository.AddInclude("ContactRoles.Organization");
            var result = await _contactRepository.FindByIdAsync(id, cancellationToken);
            return result;
        }
    }
}
