using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirst.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public DateTime FechaEvento { get; set; }

        public string? Descripcion { get; set; }

        [Required]
        public int NumeroInvitados { get; set; }

        public string Estado { get; set; } = "Pendiente";

        // IDs de servicios relacionados
        public int? SalonId { get; set; }
        public int? AnimacionId { get; set; }
        public int? DecoracionId { get; set; }
        public int? MusicaId { get; set; }

        // Datos del cliente
        [Required]
        public string ClienteNombre { get; set; } = string.Empty;

        [Required]
        public string ClienteTelefono { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string ClienteEmail { get; set; } = string.Empty;

        // Financiero
        public int Anticipo { get; set; }
        public int CostoTotal { get; set; }
        public int SaldoPendiente { get; set; }

        // Colección de detalles de mantelería
        public List<DetalleManteleriaEvento> DetallesManteleria { get; set; } = new();
    }

    public class DetalleManteleriaEvento
    {
        public int Id { get; set; }

        [Required]
        public int EventoId { get; set; }

        [Required]
        public int ServicioManteleriaId { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public int PrecioUnitario { get; set; }

        public int SubTotal { get; set; }
    }
}
