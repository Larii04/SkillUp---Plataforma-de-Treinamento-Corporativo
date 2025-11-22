using SkillUp.Domain.Entities;

namespace SkillUp.Application.Cursos.Responses
{
    public class CursoResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public string Categoria { get; set; } = null!;
        public string Nivel { get; set; } = null!;
        public string? Thumbnail { get; set; }
        public bool Publicado { get; set; }

        public CursoResponse()
        {
        }

        public CursoResponse(Curso curso)
        {
            Id = curso.Id;
            Nome = curso.Nome;
            Descricao = curso.Descricao;
            Categoria = curso.Categoria;
            Nivel = curso.Nivel.ToString();
            Thumbnail = curso.Thumbnail;
            Publicado = curso.Publicado;
        }
    }
}
