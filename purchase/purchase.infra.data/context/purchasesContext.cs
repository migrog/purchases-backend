using Microsoft.EntityFrameworkCore;
using purchase.domain.entities;
using purchase.infra.data.mapping;

namespace purchase.infra.data.context
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

        public virtual DbSet<Enumerate> Enumerate { get; set; }
        public virtual DbSet<EnumerateType> EnumerateType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<PurchaseDetail> PurchaseDetail { get; set; }

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
            modelBuilder.Entity<EnumerateType>(entity => new EnumerateTypeMap().Configure(entity));
            modelBuilder.Entity<Enumerate>(entity => new EnumerateMap().Configure(entity));
            modelBuilder.Entity<Product>(entity => new ProductMap().Configure(entity));
            modelBuilder.Entity<Purchase>(entity => new PurchaseMap().Configure(entity));
            modelBuilder.Entity<PurchaseDetail>(entity => new PurchaseDetailMap().Configure(entity));

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
