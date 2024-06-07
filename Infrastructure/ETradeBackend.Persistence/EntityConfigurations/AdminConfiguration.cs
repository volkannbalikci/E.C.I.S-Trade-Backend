using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.EntityConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETradeBackend.Persistence.EntityConfigurations;

public class AdminConfiguration : EntityTypeConfigurationBase<Admin, Guid>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.ToTable("Admins").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("ID").IsRequired();
        builder.Property(a => a.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(a => a.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(a => a.ContactNumber).HasColumnName("ContactNumber").IsRequired();
        builder.Property(a => a.RegisterNumber).HasColumnName("RegisterNumber").IsRequired();
        builder.HasOne(a => a.User);
    }
}
