using ContactManagement.ApplicationCore.Entities;
using ContactManagement.ApplicationCore.Repositories;

namespace ContactManagement.Infrastructure.Data
{
    public class ContactRepository : DbRepository<Contact>, IContactRepository
    {
        public ContactRepository(ContactManagementDbContext context) : base(context)
        {
        }
    }
}
