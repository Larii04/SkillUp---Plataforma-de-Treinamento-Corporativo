using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace SkillUp.Application.Auth.Commands
{
    public class LoginCommand: IRequest<LoginResponse>
    {
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
    }

    public class LoginResponse
    {
        public string Token { get; set; } = null!;
        public Guid UsuarioId { get; set; }
        public string Papel { get; set; } = null!;
    }

}