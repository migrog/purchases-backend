using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using purchase.domain.entities;

namespace purchase.infra.data.mapping
{
    public class PurchaseDetailMap : IEntityTypeConfiguration<PurchaseDetail>
    {
        public void Configure(EntityTypeBuilder<PurchaseDetail> entity)
        {
            entity.ToTable("purchase_detail");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");

            entity.Property(e => e.Quantity)
                .HasColumnName("quantity")
                .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.UnitPrice)
                .HasColumnName("unit_price")
                .HasColumnType("decimal(18, 2)");
        }
    }
}
