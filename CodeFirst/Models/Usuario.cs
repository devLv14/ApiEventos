using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFirst.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string TipoUsuario { get; set; } // "SUPER_ADMIN", "PROVEEDOR", "CLIENTE"

        // Solo para PROVEEDOR
        public string? NombreEmpresa { get; set; }
        public string? RUC { get; set; }
        public string? TelefonoEmpresa { get; set; }
        public string? DireccionEmpresa { get; set; }
        public string? DescripcionEmpresa { get; set; }

        // Solo para CLIENTE
        public string? TelefonoPersonal { get; set; }
        public string? DireccionPersonal { get; set; }

        public bool Activo { get; set; } = true;
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public DateTime? UltimoAcceso { get; set; }
    }
    // DTO para registro de CLIENTE
    public class RegistroClienteRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string NombreCompleto { get; set; }

        public string? Telefono { get; set; }
    }

    // DTO para registro de PROVEEDOR
    public class RegistroProveedorRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string NombreRepresentante { get; set; }

        [Required]
        public string NombreEmpresa { get; set; }

        [Required]
        public string RUC { get; set; }

        [Required]
        public string TelefonoEmpresa { get; set; }

        [Required]
        public string DireccionEmpresa { get; set; }

        public string? DescripcionEmpresa { get; set; }
    }
}
