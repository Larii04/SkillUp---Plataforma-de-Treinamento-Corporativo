using MediatR;
using SkillUp.Application.Cursos.Responses;

namespace SkillUp.Application.Cursos.Commands
{
    public class ObterTodosCursosQuery : IRequest<List<CursoResponse>>
    {
    }
}
