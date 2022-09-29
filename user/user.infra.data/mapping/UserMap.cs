using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using user.domain.entities;

namespace user.infra.data.mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(100);

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(50);

            entity.Property(e => e.Password).HasColumnName("password");
        }
    }
}
