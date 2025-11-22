using MediatR;
using Microsoft.EntityFrameworkCore;
using SkillUp.Application.Cursos.Commands;
using SkillUp.Application.Cursos.Responses;
using SkillUp.Application.Persistence;

namespace SkillUp.Application.Cursos.Handlers
{
    public class ObterCursoPorIdQueryHandler : IRequestHandler<ObterCursoPorIdQuery, CursoResponse>
    {
        private readonly ISkillUpContext _context;

        public ObterCursoPorIdQueryHandler(ISkillUpContext context)
        {
            _context = context;
        }

        public async Task<CursoResponse> Handle(ObterCursoPorIdQuery request, CancellationToken cancellationToken)
        {
            var curso = await _context.Cursos
                .Include(x => x.Modulos)
                .ThenInclude(m => m.Licoes)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (curso == null)
                throw new Exception("Curso não encontrado");

            return new CursoResponse(curso);
        }
    }
}
