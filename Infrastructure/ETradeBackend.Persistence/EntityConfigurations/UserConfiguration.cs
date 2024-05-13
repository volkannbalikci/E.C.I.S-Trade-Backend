using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.EntityConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETradeBackend.Persistence.EntityConfigurations;

public class UserConfiguration : EntityTypeConfigurationBase<User, Guid>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").HasColumnType("varbinary(MAX)");
        builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").HasColumnType("varbinary(MAX)");
        builder.Property(u => u.Status).HasColumnName("Status").IsRequired();

        builder.HasMany(u => u.UserOperationClaims);
        builder.HasOne(u => u.CorporateUser);
        builder.HasOne(u => u.IndividualUser);
        builder.HasMany(u => u.UserAddresses);
    }
}
