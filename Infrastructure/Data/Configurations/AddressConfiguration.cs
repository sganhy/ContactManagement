using ContactManagement.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace ContactManagement.Infrastructure.Data.Configurations
{
    [ExcludeFromCodeCoverage]
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public AddressConfiguration() : base()
        {
        }

        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(p => p.Id);
        }
    }
}
