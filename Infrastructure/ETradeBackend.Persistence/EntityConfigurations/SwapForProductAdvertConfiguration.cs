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

public class SwapForProductAdvertConfiguration : EntityTypeConfigurationBase<SwapForProductAdvert, Guid>
{
    public void Configure(EntityTypeBuilder<SwapForProductAdvert> builder)
    {
        builder.ToTable("SwapForProductAdverts").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.SwapAdvertId).HasColumnName("SwapAdvertId").IsRequired();
        builder.Property(p => p.DesiredProductId).HasColumnName("DesiredProductId").IsRequired();

        builder.HasOne(p => p.SwapAdvert);
        builder.HasOne(p => p.DesiredProduct);
    }
}
