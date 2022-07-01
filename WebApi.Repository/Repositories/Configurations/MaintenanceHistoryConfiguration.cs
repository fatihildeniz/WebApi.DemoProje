using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Entities;

namespace WebApi.Repository.Repositories.Configurations
{
    internal class MaintenanceHistoryConfiguration : IEntityTypeConfiguration<MaintenanceHistory>
    {
        public void Configure(EntityTypeBuilder<MaintenanceHistory> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn().HasColumnType("int4");
            builder.Property(x => x.MaintenanceID).IsRequired(true);
            builder.Property(x => x.CreateDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.ModifyDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.CreatedBy).HasDefaultValue(0);
            builder.Property(x => x.ModifiedBy).HasDefaultValue(0);

            builder.HasOne(x => x.CreatedByUser).WithMany(x => x.CreatedMaintenanceHistories).HasForeignKey(x => x.CreatedBy).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ModifiedByUser).WithMany(x => x.ModifiedMaintenanceHistories).HasForeignKey(x => x.ModifiedBy).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Maintenance).WithMany(x => x.MaintenanceHistories).HasForeignKey(x => x.MaintenanceID).OnDelete(DeleteBehavior.Restrict);




        }
    }
}
