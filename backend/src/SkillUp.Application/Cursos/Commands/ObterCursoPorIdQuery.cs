using MediatR;
using SkillUp.Application.Cursos.Responses;

namespace SkillUp.Application.Cursos.Commands
{
    public class ObterCursoPorIdQuery : IRequest<CursoResponse>
    {
        public Guid Id { get; set; }
    }
}
