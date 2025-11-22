using MediatR;
using SkillUp.Application.Questionarios.Responses;

namespace SkillUp.Application.Questionarios.Commands
{
    public class ResponderQuestionarioCommand : IRequest<ResultadoQuestionarioResponse>
    {
        public Guid UsuarioId { get; set; }
        public Guid CursoId { get; set; }
        public List<RespostaQuestaoItem> Respostas { get; set; } = new();
    }
}
