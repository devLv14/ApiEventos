using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirst.Models
{
    public class Musica
    {
        public int? Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Tipo { get; set; } = string.Empty;

        [Required]
        public decimal PrecioPorHora { get; set; }

        [Required]
        public string GeneroMusical { get; set; } = string.Empty;

        [Required]
        public string EquipoIncluido { get; set; } = string.Empty;

        public bool Disponible { get; set; } = true;
    }
}
