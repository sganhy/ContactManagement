using ContactManagement.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace ContactManagement.Infrastructure.Data.Configurations
{
    [ExcludeFromCodeCoverage]
    public class ContactConfiguration : IEntityTypeConfiguration<Contact> 
    {
        public ContactConfiguration() : base()
        {
        }

        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasKey(p => p.Id);
            builder.Property(x => x.FirstName).HasColumnName("FirstName").HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasColumnName("LastName").HasMaxLength(50).IsRequired();
            builder.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(20);
            builder.Property(x => x.Vat).HasColumnName("Vat").HasMaxLength(12);
            builder.Property(x => x.MainAddressId).HasColumnName("MainAddressId").IsRequired();

            //FK
            builder.HasOne(p => p.MainAddress).WithMany().HasForeignKey(s => s.MainAddressId);

        }
    }
}