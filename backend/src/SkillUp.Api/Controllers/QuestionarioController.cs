using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillUp.Application.Questionarios.Commands;

namespace SkillUp.Api.Controllers
{
    [ApiController]
    [Route("api/questionarios")]
    public class QuestionarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuestionarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("curso/{cursoId:guid}")]
        [Authorize]
        public async Task<IActionResult> ObterPorCurso(Guid cursoId)
        {
            var query = new ObterQuestionarioCursoQuery { CursoId = cursoId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("curso/{cursoId:guid}/responder")]
        [Authorize]
        public async Task<IActionResult> Responder(Guid cursoId, [FromBody] ResponderQuestionarioRequest request)
        {
            var command = new ResponderQuestionarioCommand
            {
                UsuarioId = request.UsuarioId,
                CursoId = cursoId,
                Respostas = request.Respostas.Select(r => new RespostaQuestaoItem
                {
                    QuestaoId = r.QuestaoId,
                    OpcaoId = r.OpcaoId
                }).ToList()
            };

            var resultado = await _mediator.Send(command);
            return Ok(resultado);
        }
    }

    public class ResponderQuestionarioRequest
    {
        public Guid UsuarioId { get; set; }
        public List<RespostaQuestaoRequestItem> Respostas { get; set; } = new();
    }

    public class RespostaQuestaoRequestItem
    {
        public Guid QuestaoId { get; set; }
        public Guid OpcaoId { get; set; }
    }
}
