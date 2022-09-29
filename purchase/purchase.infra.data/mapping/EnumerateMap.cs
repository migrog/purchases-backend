using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using purchase.domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace purchase.infra.data.mapping
{
    public class EnumerateMap : IEntityTypeConfiguration<Enumerate>
    {
        public void Configure(EntityTypeBuilder<Enumerate> entity)
        {
            entity.ToTable("enumerate");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Code)
                .HasColumnName("code")
                .HasMaxLength(20);

            entity.Property(e => e.EnumerateTypeCode).HasColumnName("enumerate_type_code");

            entity.Property(e => e.Value)
                .HasColumnName("value")
                .HasMaxLength(100);
        }
    }
}