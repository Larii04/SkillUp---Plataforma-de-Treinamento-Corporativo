using MediatR;

namespace SkillUp.Application.Cursos.Commands
{
    public class ExcluirCursoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
