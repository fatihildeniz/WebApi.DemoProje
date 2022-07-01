using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Entities;

namespace WebApi.Repository.Repositories.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
           
            builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(255);
            builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(255);
            builder.Property(x => x.PhoneNumber).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.Address).HasMaxLength(255);
            builder.Property(x=>x.CreateDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.ModifyDate).HasColumnType("timestamp without time zone");

            builder.HasOne(x => x.CreatedByUser).WithMany(x => x.CreatedUsers).HasForeignKey(x => x.CreatedBy).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ModifiedByUser).WithMany(x => x.ModifiedUsers).HasForeignKey(x => x.ModifiedBy).OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.UserAuthentication).WithOne(x => x.User).HasForeignKey<UserAuthentication>(x => x.UserID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
