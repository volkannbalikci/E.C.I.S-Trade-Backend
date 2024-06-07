using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.EntityConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETradeBackend.Persistence.EntityConfigurations;

public class AdvertConfiguration : EntityTypeConfigurationBase<Advert, Guid>
{
    public void Configure(EntityTypeBuilder<Advert> builder)
    {
        builder.ToTable("Adverts").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.AddressId).HasColumnName("AddressId").IsRequired();
        builder.Property(a => a.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(a => a.Title).HasColumnName("Title").IsRequired();
        builder.Property(a => a.Description).HasColumnName("Description").IsRequired();

        builder.HasMany(a => a.AdvertImageFiles);
        builder.HasOne(a => a.IndividualAdvert);
        builder.HasOne(a => a.CorporateAdvert);
        builder.HasOne(a => a.SwapAdvert);
        builder.HasOne(a => a.Address);
        builder.HasOne(a => a.Product);
    }
}
