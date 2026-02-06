using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirst.Models
{
    public class Animacion
    {
        public int? Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Tipo { get; set; } = string.Empty;

        [Required]
        public int DuracionHoras { get; set; }

        [Required]
        public int PrecioPorEvento { get; set; }

        [Required]
        public string PublicoObjetivo { get; set; } = string.Empty;

        public bool IncluyePersonajes { get; set; } = true;

        [Required]
        public string NivelEnergia { get; set; } = string.Empty;

        [Required]
        public string Descripcion { get; set; } 

        public bool Disponible { get; set; } = true;
    }
}
