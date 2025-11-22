using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillUp.Application.Licoes.Commands;

namespace SkillUp.Api.Controllers
{
    [ApiController]
    [Route("api/licoes")]
    public class LicaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LicaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{licaoId:guid}/concluir")]
        [Authorize]
        public async Task<IActionResult> ConcluirLicao(Guid licaoId, [FromBody] ConcluirLicaoRequest request)
        {
            var command = new ConcluirLicaoCommand
            {
                UsuarioId = request.UsuarioId,
                LicaoId = licaoId
            };

            await _mediator.Send(command);
            return NoContent();
        }
    }

    public class ConcluirLicaoRequest
    {
        public Guid UsuarioId { get; set; }
    }
}
