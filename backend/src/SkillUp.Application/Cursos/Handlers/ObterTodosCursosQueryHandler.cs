using MediatR;
using Microsoft.EntityFrameworkCore;
using SkillUp.Application.Cursos.Commands;
using SkillUp.Application.Cursos.Responses;
using SkillUp.Application.Persistence;

namespace SkillUp.Application.Cursos.Handlers
{
    public class ObterTodosCursosQueryHandler : IRequestHandler<ObterTodosCursosQuery, List<CursoResponse>>
    {
        private readonly ISkillUpContext _context;

        public ObterTodosCursosQueryHandler(ISkillUpContext context)
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
