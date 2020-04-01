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
            builder.HasKey(p => p.Id);
            builder.Property(x => x.FirstName).HasColumnName("FirstName").HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasColumnName("LastName").HasMaxLength(50).IsRequired();
            builder.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(20).IsRequired();
        }
    }
}