using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkillUp.Application.Persistence;
using SkillUp.Application.Services;

namespace SkillUp.Application.Auth.Commands
{
    public class LoginCommandHandler: IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly ISkillUpContext _context;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(ISkillUpContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

            if (usuario == null)
                throw new UnauthorizedAccessException("Usuário não encontrado");

            if (!BCrypt.Net.BCrypt.Verify(request.Senha, usuario.SenhaHash))
                throw new UnauthorizedAccessException("Senha inválida");

            var token = _tokenService.GerarToken(
                usuario.Id,
                usuario.Email,
                usuario.Nome,
                usuario.Papel.ToString()
            );

            return new LoginResponse
            {
                Token = token,
                UsuarioId = usuario.Id,
                Papel = usuario.Papel.ToString()
            };
        }
    }
}