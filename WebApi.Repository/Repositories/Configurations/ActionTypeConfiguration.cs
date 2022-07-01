using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Entities;

namespace WebApi.Repository.Repositories.Configurations
{
    internal class ActionTypeConfiguration : IEntityTypeConfiguration<ActionType>
    {
        public void Configure(EntityTypeBuilder<ActionType> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn().HasColumnType("int4");
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.CreateDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.ModifyDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.CreatedBy).HasDefaultValue(0);
            builder.Property(x => x.ModifiedBy).HasDefaultValue(0);

            builder.HasOne(x => x.CreatedByUser).WithMany(x => x.CreatedActionTypes).HasForeignKey(x => x.CreatedBy).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ModifiedByUser).WithMany(x => x.ModifiedActionTypes).HasForeignKey(x => x.ModifiedBy).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.MaintenanceHistories).WithOne(x => x.ActionType).HasForeignKey(x => x.ActionTypeID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
