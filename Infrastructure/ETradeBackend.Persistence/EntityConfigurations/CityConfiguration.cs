using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.EntityConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETradeBackend.Persistence.EntityConfigurations;

public class CityConfiguration : EntityTypeConfigurationBase<City, Guid>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.CountryId).HasColumnName("CountryId").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name").IsRequired();

        builder.HasMany(c => c.Addresses);
        builder.HasMany(c => c.Districts);
        builder.HasOne(c => c.Country);
    }
}
