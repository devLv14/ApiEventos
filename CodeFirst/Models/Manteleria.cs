using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirst.Models
{
    public class ServicioManteleria
    {
        public int Id { get; set; }

      
        public string Nombre { get; set; }

       
        public string Descripcion { get; set; }

        public string Tipo { get; set; }

     
        public string Material { get; set; }

        public string Color { get; set; }

 
        public string Medidas { get; set; }

       
        public decimal PrecioAlquiler { get; set; }

       
        public decimal? PrecioVenta { get; set; }

        
        public int StockDisponible { get; set; }

      
        public bool Disponible { get; set; }

        
        public string Categoria { get; set; }

      
        public string? ImagenUrl { get; set; }

      
        public DateTime FechaRegistro { get; set; }

        // Propiedad de navegación para detalles de evento
        //public virtual ICollection<DetalleEventoManteleria> DetallesEventos { get; set; }

        // Constructor para establecer fecha de registro
        public ServicioManteleria()
        {
            FechaRegistro = DateTime.UtcNow;
        }
    }

    // Clases para las opciones (puedes usar enums o clases estáticas)
    public static class TiposMantel
    {
        public const string Rectangular = "Rectangular";
        public const string Redondo = "Redondo";
        public const string Cuadrado = "Cuadrado";
        public const string Ovalado = "Ovalado";
        public const string Corrido = "Corrido";
    }

    public static class MaterialesMantel
    {
        public const string Algodon = "Algodón";
        public const string Poliester = "Poliéster";
        public const string Lino = "Lino";
        public const string Seda = "Seda";
        public const string Tul = "Tul";
        public const string Organza = "Organza";
    }

    public static class CategoriasMantel
    {
        public const string Boda = "Boda";
        public const string Corporativo = "Corporativo";
        public const string Social = "Social";
        public const string Infantil = "Infantil";
        public const string Gala = "Gala";
    }
}
