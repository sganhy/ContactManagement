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
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasKey(p => p.Id);
            builder.Property(x => x.OrganizationId).HasColumnName("CompanyId");
            builder.Property(x => x.ContactId).HasColumnName("ContactId");

            // FK
            builder.HasOne(p => p.Organization).WithMany().HasForeignKey(s => s.OrganizationId);
        }
    }
}
