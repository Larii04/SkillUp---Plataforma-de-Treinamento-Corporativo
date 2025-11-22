using MediatR;
using Microsoft.EntityFrameworkCore;
using SkillUp.Application.Cursos.Commands;
using SkillUp.Application.Cursos.Responses;
using SkillUp.Infra.Persistence;

namespace SkillUp.Application.Cursos.Handlers
{
    public class ObterTodosCursosQueryHandler : IRequestHandler<ObterTodosCursosQuery, List<CursoResponse>>
    {
        private readonly SkillUpContext _context;

        public ObterTodosCursosQueryHandler(SkillUpContext context)
        {
            _context = context;
        }

        public async Task<List<CursoResponse>> Handle(ObterTodosCursosQuery request, CancellationToken cancellationToken)
        {
            var cursos = await _context.Cursos.ToListAsync(cancellationToken);
            return cursos.Select(c => new CursoResponse(c)).ToList();
        }
    }
}
