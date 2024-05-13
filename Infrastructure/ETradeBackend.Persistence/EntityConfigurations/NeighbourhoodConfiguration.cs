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

public class NeighbourhoodConfiguration : EntityTypeConfigurationBase<Neighbourhood, Guid>
{
    public void Configure(EntityTypeBuilder<Neighbourhood> builder)
    {
        builder.ToTable("Neighbourhoods").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.DistrictId).HasColumnName("DistrictId").IsRequired();
        builder.Property(a => a.Name).HasColumnName("Name").IsRequired();

        builder.HasMany(a => a.Addresses);
        builder.HasOne(a => a.District);
    }
}