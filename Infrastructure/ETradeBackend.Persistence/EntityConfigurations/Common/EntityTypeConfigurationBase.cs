using Framework.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Persistence.EntityConfigurations.Common;

public class EntityTypeConfigurationBase<TEntity, TId> : IEntityTypeConfiguration<TEntity>
       where TEntity : EntityBase<TId>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");
    }
}
