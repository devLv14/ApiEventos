using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst.Contexts
{
    public class ManteleriaDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=servicioeventosDB;User ID=sa;Password=modernoSAO;Trusted_Connection=False;MultipleActiveResultSets=True;TrustServerCertificate=True;");
        }

 
        

        public DbSet<Animacion> Animaciones { get; set; }
        public DbSet<Decoracion> Decoraciones { get; set; }
        public DbSet<ServicioManteleria> ServiciosManteleria { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Salon> Salones { get; set; }
        //public DbSet<Evento> Eventos { get; set; }
        //public DbSet<DetalleEventoManteleria> DetallesEventoManteleria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
