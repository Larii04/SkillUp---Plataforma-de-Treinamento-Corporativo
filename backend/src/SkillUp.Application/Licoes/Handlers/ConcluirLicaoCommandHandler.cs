using MediatR;
using SkillUp.Application.Licoes.Commands;
using SkillUp.Application.Services;

namespace SkillUp.Application.Licoes.Handlers
{
    public class ConcluirLicaoCommandHandler : IRequestHandler<ConcluirLicaoCommand, Unit>
    {
        private readonly IProgressoService _progressoService;

        public ConcluirLicaoCommandHandler(IProgressoService progressoService)
        {
            _progressoService = progressoService;
        }

        public async Task<Unit> Handle(ConcluirLicaoCommand request, CancellationToken cancellationToken)
        {
            await _progressoService.ConcluirLicaoAsync(request.UsuarioId, request.LicaoId);
            return Unit.Value;
        }
    }
}
