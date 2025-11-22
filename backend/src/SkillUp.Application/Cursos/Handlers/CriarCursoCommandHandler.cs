using MediatR;
using SkillUp.Application.Cursos.Commands;
using SkillUp.Application.Cursos.Responses;
using SkillUp.Domain.Entities;
using SkillUp.Application.Persistence;

namespace SkillUp.Application.Cursos.Handlers
{
    public class CriarCursoCommandHandler : IRequestHandler<CriarCursoCommand, CursoResponse>
    {
        private readonly ISkillUpContext _context;

        public CriarCursoCommandHandler(ISkillUpContext context)
        {
            _context = context;
        }

        public async Task<CursoResponse> Handle(CriarCursoCommand request, CancellationToken cancellationToken)
        {
            var curso = new Curso
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Descricao = request.Descricao,
                Categoria = request.Categoria,
                Nivel = request.Nivel,
                Thumbnail = request.Thumbnail,
                Publicado = request.Publicado
            };

            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync(cancellationToken);

            return new CursoResponse(curso);
        }
    }
}
