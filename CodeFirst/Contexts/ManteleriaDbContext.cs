using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Contexts
{
    public class ManteleriaDbContext : DbContext
    {

        public ManteleriaDbContext(DbContextOptions<ManteleriaDbContext> options)
             : base(options)
        { }


        public DbSet<Salon> Salones { get; set; }
        public DbSet<Animacion> Animaciones { get; set; }
        public DbSet<Decoracion> Decoraciones { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Manteleria> Mantelerias { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<DetalleManteleriaEvento> DetallesManteleriaEvento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración mínima para las relaciones
            modelBuilder.Entity<DetalleManteleriaEvento>()
                .HasKey(d => d.Id);
        }
    }
}