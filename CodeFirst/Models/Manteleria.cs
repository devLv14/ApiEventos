using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirst.Models
{
    public class Manteleria
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; }

        public string Tipo { get; set; } = string.Empty;
        [Required]
        public string Material { get; set; } = string.Empty;

        [Required]
        public string Color { get; set; } = string.Empty;

        [Required]
        public string Medidas { get; set; } = string.Empty;
        [Required]
        public decimal PrecioAlquiler { get; set; }
        public decimal? PrecioVenta { get; set; }

        public int StockDisponible { get; set; }
        public bool Disponible { get; set; } = true;

        public string Categoria { get; set; } = string.Empty;

        public string? ImagenUrl { get; set; }

        public DateTime FechaRegistro { get; set; } 
    }
}
