
using Microsoft.EntityFrameworkCore;
using user.domain.entities;
using user.infra.data.mapping;

namespace user.infra.data.context
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
        public virtual DbSet<User> User { get; set; }

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
            
            modelBuilder.Entity<User>(entity => new UserMap().Configure(entity));
           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
