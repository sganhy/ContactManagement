using ContactManagement.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;


namespace ContactManagement.Infrastructure.Data.Configurations
{
    [ExcludeFromCodeCoverage]
    public class ContactRoleConfiguration : IEntityTypeConfiguration<ContactRole>
    {
        public ContactRoleConfiguration() : base()
        {
        }

        public void Configure(EntityTypeBuilder<ContactRole> builder)
        {
            builder.ToTable("ContactRole");
            builder.HasKey(p => p.Id);
        }
    }
}
