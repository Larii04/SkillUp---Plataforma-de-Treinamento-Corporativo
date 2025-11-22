using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillUp.Application.Services;
using SkillUp.Infra.Persistence;

namespace SkillUp.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly SkillUpContext _context;
        private readonly ITokenService _tokenService;

        public AuthController(SkillUpContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (usuario == null)
                return Unauthorized("Usuário não encontrado");

            if (!BCrypt.Net.BCrypt.Verify(request.Senha, usuario.SenhaHash))
                return Unauthorized("Senha inválida");

            var token = _tokenService.GerarToken(
                usuario.Id,
                usuario.Email,
                usuario.Nome,
                usuario.Papel.ToString()
            );

            return Ok(new
            {
                token,
                usuario = new 
                {
                    usuario.Id,
                    usuario.Nome,
                    usuario.Email,
                    Papel = usuario.Papel.ToString()
                }
            });
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
    }
}
