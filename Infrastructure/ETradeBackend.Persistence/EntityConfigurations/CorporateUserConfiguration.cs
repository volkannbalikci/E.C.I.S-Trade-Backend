using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.EntityConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETradeBackend.Persistence.EntityConfigurations;

public class CorporateUserConfiguration : EntityTypeConfigurationBase<CorporateUser, Guid>
{
    public void Configure(EntityTypeBuilder<CorporateUser> builder)
    {
        builder.ToTable("CorporateUsers").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(c => c.CompanyName).HasColumnName("CompanyName").IsRequired();
        builder.Property(c => c.TaxIdentityNumber).HasColumnName("TaxIdentityNumber").IsRequired();

        builder.HasOne(c => c.User);
        builder.HasMany(c => c.CorporateAdverts);
    }
}
