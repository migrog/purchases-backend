using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using purchase.domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace purchase.infra.data.mapping
{
    public class EnumerateTypeMap : IEntityTypeConfiguration<EnumerateType>
    {
        public void Configure(EntityTypeBuilder<EnumerateType> entity)
        {
            entity.ToTable("enumerate_type");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Code).HasColumnName("code");

            entity.Property(e => e.Description)
                .HasColumnName("description")
                .HasMaxLength(100);
        }
    }
}
