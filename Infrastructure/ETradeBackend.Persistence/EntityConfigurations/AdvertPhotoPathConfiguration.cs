using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.EntityConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETradeBackend.Persistence.EntityConfigurations;

public class AdvertPhotoPathConfiguration : EntityTypeConfigurationBase<AdvertPhotoPath, Guid>
{
    public void Configure(EntityTypeBuilder<AdvertPhotoPath> builder)
    {
        builder.ToTable("AdvertPhotoPaths").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.AdvertId).HasColumnName("AdvertId").IsRequired();
        builder.Property(a => a.PhotoPath).HasColumnName("PhotoPath").IsRequired();
        builder.Property(a => a.IsMain).HasColumnName("IsMain").IsRequired();

        builder.HasOne(a => a.Advert);
    }
}
