using MediatR;
using SkillUp.Application.Cursos.Commands;
using SkillUp.Application.Persistence;

namespace SkillUp.Application.Cursos.Handlers
{
    public class ExcluirCursoCommandHandler : IRequestHandler<ExcluirCursoCommand, bool>
    {
        private readonly ISkillUpContext _context;

        public ExcluirCursoCommandHandler(ISkillUpContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(ExcluirCursoCommand request, CancellationToken cancellationToken)
        {
            var curso = await _context.Cursos.FindAsync(new object[] { request.Id }, cancellationToken);

            if (curso == null)
                return false;

            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
