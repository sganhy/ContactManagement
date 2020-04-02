using ContactManagement.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasKey(p => p.Id);
            builder.Property(x => x.AddressId).HasColumnName("AddressId").IsRequired();
            builder.Property(x => x.CompanyId).HasColumnName("CompanyId").IsRequired();

            // FK
            builder.HasOne(p => p.Address).WithMany().HasForeignKey(s => s.AddressId);
        }
    }
}
