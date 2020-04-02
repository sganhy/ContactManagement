using ContactManagement.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace ContactManagement.Infrastructure.Data.Configurations
{
    [ExcludeFromCodeCoverage]
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public CompanyConfiguration() : base()
        {
        }

        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasKey(p => p.Id);
            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Vat).HasColumnName("Vat").HasMaxLength(12).IsRequired();
            builder.Property(x => x.MainAddressId).HasColumnName("MainAddressId").IsRequired();
            // FK
            builder.HasOne(p => p.MainAddress).WithMany().HasForeignKey(s => s.MainAddressId);
        }
    }
}
