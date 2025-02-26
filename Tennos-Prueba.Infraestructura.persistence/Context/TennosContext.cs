

using Microsoft.EntityFrameworkCore;
using Tennos_Prueba.core.Domain.Entidades;

namespace Tennos_Prueba.Infraestructura.persistence.Context
{
    public class TennosContext : DbContext
    {
        public TennosContext(DbContextOptions<TennosContext> options) : base(options)
        {
        }

        public DbSet<Productos> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Productos>().HasKey(p => p.ProductoID);

        }
    }
}
