using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Entities;

namespace WebApi.Repository.Repositories.Configurations
{
    internal class UserAuthenticationConfiguration : IEntityTypeConfiguration<UserAuthentication>
    {
        public void Configure(EntityTypeBuilder<UserAuthentication> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn().HasColumnType("int4");
            builder.Property(x => x.UserID).IsRequired(true);
            builder.Property(x => x.UserName).IsRequired(true);
            builder.Property(x => x.Password).IsRequired(true);
            builder.Property(x => x.UserRole).IsRequired(true);

            builder.HasOne(x => x.User).WithOne(x => x.UserAuthentication).HasForeignKey<UserAuthentication>(x => x.UserID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
