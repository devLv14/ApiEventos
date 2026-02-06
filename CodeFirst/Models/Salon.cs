using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirst.Models
{
    public class Salon
    {
        public int? Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        [Required]
        public int Capacidad { get; set; }

        [Required]
        public decimal PrecioHora { get; set; }

        [Required]
        public string Ubicacion { get; set; } = string.Empty;

        [Required]
        public string TipoEvento { get; set; } = string.Empty;

        public string? ServiciosIncluidos { get; set; }

        public bool Disponible { get; set; } = true;
    }
}
