using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using product.domain.entities;
using product.infra.data.mapping;

namespace product.infra.data.context
{
    public partial class purchasesContext : DbContext
    {
        public purchasesContext()
        {
        }

        public purchasesContext(DbContextOptions<purchasesContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                var cnx = new AppConfiguration().SqlDataConnection;
                optionsBuilder.UseSqlServer(cnx);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>(entity => new ProductMap().Configure(entity));


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
