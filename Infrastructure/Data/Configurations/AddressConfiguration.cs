using ContactManagement.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
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
            //builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.HasKey(p => p.Id);
            builder.Property(x => x.Description).HasColumnName("Address").HasMaxLength(255).IsRequired();
            builder.Property(x => x.ZipCode).HasColumnName("ZipCode").HasMaxLength(20).IsRequired();
            builder.Property(x => x.City).HasColumnName("City").HasMaxLength(50).IsRequired();
        }
    }
}
