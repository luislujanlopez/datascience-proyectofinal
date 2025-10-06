using Microsoft.AspNetCore.Mvc;
using ProyectoFinalWebApi.DTOs;
using ProyectoFinalWebApi.Services;

namespace ProyectoFinalWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioLoginDto dto)
        {
            if (dto.Usuario == "test" && dto.Password == "1234")
            {
                var token = _tokenService.CrearToken(dto.Usuario);
                return Ok(new { token });
            }

            return Unauthorized("Usuario o contraseña inválidos");
        }
    }
}
