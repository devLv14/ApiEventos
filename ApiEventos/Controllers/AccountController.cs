/*using CodeFirst.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace ApiEventos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        [HttpPost("registro/cliente")]
        public async Task<IActionResult> RegistrarCliente(RegistroClienteRequest request)
        {
            // Validar email único
            // Crear usuario con TipoUsuario = "CLIENTE"
            // Generar token JWT
            return Ok(new { token, user });
        }

        [HttpPost("registro/proveedor")]
        public async Task<IAResult> RegistrarProveedor(RegistroProveedorRequest request)
        {
            // Validar email único
            // Validar RUC único
            // Crear usuario con TipoUsuario = "PROVEEDOR" y Activo = false
            // Enviar notificación al SUPER_ADMIN para aprobación
            return Ok(new
            {
                message = "Registro enviado para aprobación. Recibirá un email cuando sea activado.",
                requiresApproval = true
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            // Verificar credenciales
            // Verificar que usuario esté Activo (especial para proveedores)
            // Generar token JWT con claims de rol
            return Ok(new
            {
                token,
                user,
                rol = usuario.TipoUsuario
            });
        }

        [Authorize(Roles = "SUPER_ADMIN")]
        [HttpPost("aprobar-proveedor/{id}")]
        public async Task<IActionResult> AprobarProveedor(int id)
        {
            // Activar cuenta de proveedor
            // Enviar email de confirmación
            return Ok();
        }
    }
}*/
