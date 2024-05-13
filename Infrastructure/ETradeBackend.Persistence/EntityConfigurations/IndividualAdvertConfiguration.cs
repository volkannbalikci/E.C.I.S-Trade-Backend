using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.EntityConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETradeBackend.Persistence.EntityConfigurations;

public class IndividualAdvertConfiguration : EntityTypeConfigurationBase<IndividualAdvert, Guid>
{
    public void Configure(EntityTypeBuilder<IndividualAdvert> builder)
    {
        builder.ToTable("IndividualAdverts").HasKey(i => i.Id);

        builder.Property(i => i.Id).HasColumnName("Id").IsRequired();
        builder.Property(i => i.AdvertId).HasColumnName("AdvertId").IsRequired();
        builder.Property(i => i.IndividualUserId).HasColumnName("IndividualUserId").IsRequired();
        builder.Property(i => i.Price).HasColumnName("Price").IsRequired();
        builder.Property(i => i.Bargain).HasColumnName("Bargain").IsRequired();


        builder.HasOne(i => i.IndividualUser);
        builder.HasOne(i => i.Advert);
    }
}
