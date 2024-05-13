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

public class AddressConfiguration : EntityTypeConfigurationBase<Address, Guid>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.CountryId).HasColumnName("CountryId").IsRequired();
        builder.Property(a => a.CityId).HasColumnName("CityId").IsRequired();
        builder.Property(a => a.DistrictId).HasColumnName("DistrictId").IsRequired();
        builder.Property(a => a.NeighbourhoodId).HasColumnName("NeighbourhoodId").IsRequired();
        builder.Property(a => a.PostalCode).HasColumnName("PostalCode").IsRequired();
        builder.Property(a => a.AddressDetails).HasColumnName("AddressDetails").IsRequired();

        builder.HasMany(a => a.Adverts);
        builder.HasMany(a => a.UserAddresses);
        builder.HasOne(a => a.Country);
        builder.HasOne(a => a.City);
        builder.HasOne(a => a.District);
        builder.HasOne(a => a.Neighbourhood);
    }
}