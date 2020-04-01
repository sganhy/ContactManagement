using ContactManagement.ApplicationCore.Entities;
using ContactManagement.ApplicationCore.Repositories;

namespace ContactManagement.Infrastructure.Data
{
    public class OrganizationRepository : DbRepository<Company>, ICompanyRepository
    {
        public OrganizationRepository(ContactManagementDbContext context) : base(context) 
        {
        }
    }
}