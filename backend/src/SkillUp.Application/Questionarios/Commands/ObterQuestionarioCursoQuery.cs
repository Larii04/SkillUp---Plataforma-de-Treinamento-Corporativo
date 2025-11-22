using MediatR;
using SkillUp.Application.Questionarios.Responses;

namespace SkillUp.Application.Questionarios.Commands
{
    public class ObterQuestionarioCursoQuery : IRequest<QuestionarioCursoResponse>
    {
        public Guid CursoId { get; set; }
    }
}
