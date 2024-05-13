using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.EntityConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETradeBackend.Persistence.EntityConfigurations;

public class CorporateAdvertConfiguration : EntityTypeConfigurationBase<CorporateAdvert, Guid>
{
    public void Configure(EntityTypeBuilder<CorporateAdvert> builder)
    {
        builder.ToTable("CorporateAdverts").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.AdvertId).HasColumnName("AdvertId").IsRequired();
        builder.Property(c => c.CorporateUserId).HasColumnName("CorporateUserId").IsRequired();
        builder.Property(c => c.UnitPrice).HasColumnName("UnitPrice").IsRequired();
        builder.Property(c => c.StockAmount).HasColumnName("StockAmount").IsRequired();

        builder.HasOne(c => c.CorporateUser);
        builder.HasOne(c => c.Advert);
    }
}
