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

public class SwapAdvertConfiguration : EntityTypeConfigurationBase<SwapAdvert, Guid>
{
    public void Configure(EntityTypeBuilder<SwapAdvert> builder)
    {
        builder.ToTable("SwapAdverts").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.AdvertId).HasColumnName("AdvertId").IsRequired();
        builder.Property(p => p.IndividualUserId).HasColumnName("IndividualUserId").IsRequired();

        builder.HasOne(p => p.Advert);
        builder.HasOne(p => p.IndividualUser);
        builder.HasOne(p => p.SwapForProductAdvert);
        builder.HasOne(p => p.SwapForCategoryAdvert);
    }
}

