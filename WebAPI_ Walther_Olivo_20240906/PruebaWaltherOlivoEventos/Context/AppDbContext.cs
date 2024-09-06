using Microsoft.EntityFrameworkCore;
using PruebaWaltherOlivoEventos.Models;

namespace PruebaWaltherOlivoEventos.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<TipoPrestamo> TipoPrestamos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Prestamo>()
                .HasKey(p => p.PrestamoId);

            modelBuilder.Entity<TipoPrestamo>()
                .HasKey(tp => tp.TipoPrestamoId);

            // Relación entre Prestamo y TipoPrestamo
            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.TipoPrestamo)
                .WithMany()
                .HasForeignKey(p => p.TipoPrestamoId);
        }
    }
}
