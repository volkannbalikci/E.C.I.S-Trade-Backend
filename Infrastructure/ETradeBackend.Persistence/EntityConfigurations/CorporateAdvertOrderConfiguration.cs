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

public class CorporateAdvertOrderConfiguration : EntityTypeConfigurationBase<CorporateAdvertOrder, Guid>
{
    public void Configure(EntityTypeBuilder<CorporateAdvertOrder> builder)
    {
        builder.ToTable("CorporateAdvertOrders").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.IndividualUserId).HasColumnName("IndividualUserId").IsRequired();
        builder.Property(a => a.UserAddressId).HasColumnName("UserAddressId").IsRequired();
        builder.Property(a => a.Description).HasColumnName("Description").IsRequired();
        builder.Property(a => a.Code).HasColumnName("Code").IsRequired();
        builder.Property(a => a.TotalPrice).HasColumnName("TotalPrice").IsRequired();

        builder.HasOne(a => a.IndividualUser);
        builder.HasOne(a => a.UserAddress);
        builder.HasMany(a => a.CorporateAdvertOrderItems);
    }
}
