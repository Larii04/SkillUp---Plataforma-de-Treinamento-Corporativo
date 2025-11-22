using MediatR;
using Microsoft.EntityFrameworkCore;
using SkillUp.Application.Cursos.Commands;
using SkillUp.Application.Cursos.Responses;
using SkillUp.Infra.Persistence;

namespace SkillUp.Application.Cursos.Handlers
{
    public class AtualizarCursoCommandHandler : IRequestHandler<AtualizarCursoCommand, CursoResponse>
    {
        private readonly SkillUpContext _context;

        public AtualizarCursoCommandHandler(SkillUpContext context)
        {
            _context = context;
        }

        public async Task<CursoResponse> Handle(AtualizarCursoCommand request, CancellationToken cancellationToken)
        {
            var curso = await _context.Cursos.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (curso == null)
                throw new Exception("Curso não encontrado");

            curso.Nome = request.Nome;
            curso.Descricao = request.Descricao;
            curso.Categoria = request.Categoria;
            curso.Nivel = request.Nivel;
            curso.Thumbnail = request.Thumbnail;
            curso.Publicado = request.Publicado;

            await _context.SaveChangesAsync(cancellationToken);

            return new CursoResponse(curso);
        }
    }
}
