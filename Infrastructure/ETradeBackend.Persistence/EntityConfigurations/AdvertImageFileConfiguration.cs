using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.EntityConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Persistence.EntityConfigurations;
internal class AdvertImageFileConfiguration : EntityTypeConfigurationBase<AdvertImageFile, Guid>
{
    public void Configure(EntityTypeBuilder<AdvertImageFile> builder)
    {
        builder.ToTable("AdvertImageFiles").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.AdvertId).HasColumnName("AdvertId").IsRequired();
        builder.Property(a => a.Showcase).HasColumnName("Showcase").IsRequired();
        builder.Property(a => a.FileName).HasColumnName("FileName").IsRequired();
        builder.Property(a => a.Path).HasColumnName("Path").IsRequired();
        builder.Property(a => a.Storage).HasColumnName("Storage").IsRequired();

        builder.HasOne(a => a.Advert);
    }
}
