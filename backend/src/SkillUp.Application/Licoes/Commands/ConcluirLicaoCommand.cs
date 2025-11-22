using MediatR;

namespace SkillUp.Application.Licoes.Commands
{
    public class ConcluirLicaoCommand : IRequest<Unit>
    {
        public Guid UsuarioId { get; set; }
        public Guid LicaoId { get; set; }
    }
}
