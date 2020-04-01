using ContactManagement.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Infrastructure.Data
{
    public class ContactManagementDbContext : DbContext
    {

        private readonly string _contextName;

        public ContactManagementDbContext(DbContextOptions options) : base(options)
        {
            _contextName = options.ContextType.Name;
        }


        //Turn DbSet virtual to enable in memory mocking of the DbContext
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Company> Organizations { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<ContactRole> ContactRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyAllConfigurations(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        private void ApplyAllConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}
