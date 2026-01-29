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

     
        public string Nombre { get; set; }

       
        public string? Descripcion { get; set; }

       
        public int Capacidad { get; set; }

    
        public decimal PrecioHora { get; set; }

       
        public string Ubicacion { get; set; }

     
        public string TipoEvento { get; set; }

        public string? ServiciosIncluidos { get; set; }

       
        public string Disponible { get; set; } // 'Sí' o 'No'

        // Propiedad de navegación para eventos 
        //public virtual ICollection<Evento> Eventos { get; set; }

        // Método para convertir a booleano si lo necesitas
       
        public bool EstaDisponible => Disponible.Equals("Sí", StringComparison.OrdinalIgnoreCase);
    }
}
