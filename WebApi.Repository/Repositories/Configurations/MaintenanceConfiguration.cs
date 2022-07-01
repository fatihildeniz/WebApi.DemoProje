using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Entities;

namespace WebApi.Repository.Repositories.Configurations
{
    internal class MaintenanceConfiguration : IEntityTypeConfiguration<Maintenance>
    {
        public void Configure(EntityTypeBuilder<Maintenance> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn().HasColumnType("int4");
            builder.Property(x => x.ResponsibleUserID).IsRequired(true);
            builder.Property(x=>x.VehicleID).IsRequired(true);
            builder.Property(x => x.CreateDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.ModifyDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.CreatedBy).HasDefaultValue(0);
            builder.Property(x => x.ModifiedBy).HasDefaultValue(0);

            builder.HasOne(x => x.CreatedByUser).WithMany(x => x.CreatedMaintenances).HasForeignKey(x => x.CreatedBy).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ModifiedByUser).WithMany(x => x.ModifiedMaintenances).HasForeignKey(x => x.ModifiedBy).OnDelete(DeleteBehavior.Restrict);



            builder.HasOne(x => x.User).WithMany(x => x.Maintenances).HasForeignKey(x => x.UserID).OnDelete(DeleteBehavior.Restrict);



            builder.HasOne(x => x.ResponsibleUser).WithMany(x => x.ResponsibleMaintenances).HasForeignKey(x => x.ResponsibleUserID).OnDelete(DeleteBehavior.Restrict);




        }
    }
}
