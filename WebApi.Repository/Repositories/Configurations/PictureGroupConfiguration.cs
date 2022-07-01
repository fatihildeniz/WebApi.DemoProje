﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Entities;

namespace WebApi.Repository.Repositories.Configurations
{
    internal class PictureGroupConfiguration : IEntityTypeConfiguration<PictureGroup>
    {
        public void Configure(EntityTypeBuilder<PictureGroup> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn().HasColumnType("int4");
            builder.Property(x => x.CreateDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.ModifyDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.CreatedBy).HasDefaultValue(0);
            builder.Property(x => x.ModifiedBy).HasDefaultValue(0);


            builder.HasOne(x => x.CreatedByUser).WithMany(x => x.CreatedPictureGroups).HasForeignKey(x => x.CreatedBy).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ModifiedByUser).WithMany(x => x.ModifiedPictureGroups).HasForeignKey(x => x.ModifiedBy).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Maintenances).WithOne(x => x.PictureGroup).HasForeignKey(x => x.PictureGroupID).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
