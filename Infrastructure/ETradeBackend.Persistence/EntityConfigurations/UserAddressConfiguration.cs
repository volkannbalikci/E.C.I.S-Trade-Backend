using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.EntityConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETradeBackend.Persistence.EntityConfigurations;

public class UserAddressConfiguration : EntityTypeConfigurationBase<UserAddress, Guid>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.ToTable("UserAddresses").HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(u => u.AddressId).HasColumnName("AddressId").IsRequired();
        builder.Property(u => u.IsMain).HasColumnName("IsMain").IsRequired();

        builder.HasOne(u => u.Address);
        builder.HasOne(u => u.User);
    }
}
