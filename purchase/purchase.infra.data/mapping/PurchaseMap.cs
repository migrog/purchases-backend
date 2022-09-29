using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using purchase.domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace purchase.infra.data.mapping
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> entity)
        {
            entity.ToTable("purchase");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.CreateAt)
                .HasColumnName("create_at")
                .HasColumnType("datetime");

            entity.Property(e => e.CurrencyTypeEnum)
                .IsRequired()
                .HasColumnName("currency_type_enum")
                .HasMaxLength(20);

            entity.Property(e => e.Total)
                .HasColumnName("total")
                .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.UserId).HasColumnName("user_id");
        }
    }
}
