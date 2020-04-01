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

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async ValueTask<long> CreateAsync(Contact contact, CancellationToken cancellationToken = default)
        {
            contact.MainAddressId = 1;
            _contactRepository.Add(contact);
            await _contactRepository.CommitAsync(cancellationToken);
            return contact.Id;
        }

        public async ValueTask DeleteByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            _contactRepository.RemoveById(id);
            await _contactRepository.CommitAsync(cancellationToken);
        }

        public ValueTask<IEnumerable<Contact>> GetAll(long id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }


        public async ValueTask<IEnumerable<Contact>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = new List<Contact>();
            return result;
        }

        public async ValueTask ModifyAsync(long contactId, Contact contact, CancellationToken cancellationToken = default)
        {
            _contactRepository.Update(contact);
            await _contactRepository.CommitAsync(cancellationToken);
        }

        public async ValueTask<Contact> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            var result = new Contact();
            result.FirstName = "Stefan";
            result.LastName = "Zweig";
            return result;
        }
    }
}
