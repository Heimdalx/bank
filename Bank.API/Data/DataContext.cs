using Bank.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank.API.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Cuenta>().HasIndex("ClienteId", "NumeroCuenta").IsUnique();
            modelBuilder.Entity<Movimiento>().HasIndex("CuentaId","Id").IsUnique();
        }
    }
}
