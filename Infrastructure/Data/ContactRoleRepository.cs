using ContactManagement.ApplicationCore.Entities;
using ContactManagement.ApplicationCore.Repositories;

namespace ContactManagement.Infrastructure.Data
{
    public class ContactRoleRepository : DbRepository<ContactRole>, IContactRoleRepository
    {
        public ContactRoleRepository(ContactManagementDbContext context) : base(context)
        {
        }
    }
}
