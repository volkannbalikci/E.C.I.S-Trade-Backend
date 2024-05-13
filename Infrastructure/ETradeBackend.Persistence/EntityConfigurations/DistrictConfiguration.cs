using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.EntityConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETradeBackend.Persistence.EntityConfigurations;

public class DistrictConfiguration : EntityTypeConfigurationBase<District, Guid>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        builder.ToTable("Districts").HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("Id").IsRequired();
        builder.Property(d => d.CityId).HasColumnName("CityId").IsRequired();
        builder.Property(d => d.Name).HasColumnName("Name").IsRequired();

        builder.HasMany(d => d.Addresses);
        builder.HasMany(d => d.Neighbourhoods);
        builder.HasOne(d => d.City);
    }
}
