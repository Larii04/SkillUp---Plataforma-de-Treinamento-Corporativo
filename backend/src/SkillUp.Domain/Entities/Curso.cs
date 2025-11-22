using SkillUp.Domain.Enums;

namespace SkillUp.Domain.Entities
{
    public class Curso
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public string Categoria { get; set; } = null!;
        public NivelCurso Nivel { get; set; }

        public string? Thumbnail { get; set; }
        public bool Publicado { get; set; }

        public List<Modulo> Modulos { get; set; } = new();
        public List<Questao> Questoes { get; set; } = new();
    }
}
