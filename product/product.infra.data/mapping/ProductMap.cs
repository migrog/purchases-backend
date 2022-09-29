using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using product.domain.entities;

namespace product.infra.data.mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable("product");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.CurrencyTypeEnum)
                .HasColumnName("currency_type_enum")
                .HasMaxLength(20);

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.UnitPrice)
                .HasColumnName("unit_price")
                .HasColumnType("decimal(18, 2)");
        }
    }
}
