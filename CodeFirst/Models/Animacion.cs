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

       
        public string Nombre { get; set; }

  
        public string Tipo { get; set; }

        
        public decimal DuracionHoras { get; set; }

        
        public decimal PrecioPorEvento { get; set; }

        
        public string PublicoObjetivo { get; set; }

     
        public bool IncluyePersonajes { get; set; }

    
        public string NivelEnergia { get; set; }

       
        public string Descripcion { get; set; }

     
        public bool Disponible { get; set; }

        // Propiedad de navegación para eventos
        //public virtual ICollection<Evento> Eventos { get; set; }
    }
}
