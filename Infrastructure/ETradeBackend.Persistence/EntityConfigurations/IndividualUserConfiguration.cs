using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.EntityConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETradeBackend.Persistence.EntityConfigurations;

public class IndividualUserConfiguration : EntityTypeConfigurationBase<IndividualUser, Guid>
{
    //public void Configure(EntityTypeBuilder<IndividualUser> builder)
    //{
    //    builder.ToTable("IndividualUsers").HasKey(i => i.Id);

    //    builder.Property(i => i.Id).HasColumnName("id").IsRequired();
    //    builder.Property(i => i.UserId).HasColumnName("UserId").IsRequired();
    //    builder.Property(i => i.FirstName).HasColumnName("FirstName").IsRequired();
    //    builder.Property(i => i.LastName).HasColumnName("LastName").IsRequired();
    //    builder.Property(i => i.UserName).HasColumnName("UserName").IsRequired();
    //    //builder.Property(i => i.Email).HasColumnName("Email").IsRequired();

    //    builder.HasOne(i => i.User);
    //    builder.HasMany(i => i.IndividualAdverts);
    //    builder.HasMany(i => i.SwapAdverts);
    //    builder.HasMany(i => i.Admins);
    //    builder.HasMany(i => i.Adverts);
    //}
}
