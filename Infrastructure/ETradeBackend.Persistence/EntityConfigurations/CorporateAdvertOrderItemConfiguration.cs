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

public class CorporateAdvertOrderItemConfiguration : EntityTypeConfigurationBase<CorporateAdvertOrderItem, Guid>
{
    public void Configure(EntityTypeBuilder<CorporateAdvertOrderItem> builder)
    {
        builder.ToTable("CorporateAdvertOrderItems").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.CorporateAdvertOrderId).HasColumnName("CorporateAdvertOrderId").IsRequired();
        builder.Property(a => a.CorporateAdvertId).HasColumnName("CorporateAdvertId").IsRequired();
        builder.Property(a => a.Amount).HasColumnName("Amount").IsRequired();
        builder.Property(a => a.BoughtPrice).HasColumnName("BoughtPrice").IsRequired();
        builder.Property(a => a.TotalPrice).HasColumnName("TotalPrice").IsRequired();

        builder.HasOne(a => a.CorporateAdvertOrder);
        builder.HasOne(a => a.CorporateAdvert);
    }
}
