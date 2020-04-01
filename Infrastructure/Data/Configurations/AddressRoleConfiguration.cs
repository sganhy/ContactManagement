using ContactManagement.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace ContactManagement.Infrastructure.Data.Configurations
{
    public class AddressRoleConfiguration : IEntityTypeConfiguration<AddressRole>
    {
        public AddressRoleConfiguration() : base()
        {
        }

        public void Configure(EntityTypeBuilder<AddressRole> builder)
        {
            builder.ToTable("AddressRole");
            builder.HasKey(p => p.Id);
        }
    }
}
