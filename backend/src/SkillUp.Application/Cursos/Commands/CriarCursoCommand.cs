using MediatR;
using SkillUp.Application.Cursos.Responses;
using SkillUp.Domain.Enums;

namespace SkillUp.Application.Cursos.Commands
{
    public class CriarCursoCommand : IRequest<CursoResponse>
    {
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public string Categoria { get; set; } = null!;
        public NivelCurso Nivel { get; set; }
        public string? Thumbnail { get; set; }
        public bool Publicado { get; set; }
    }
}
