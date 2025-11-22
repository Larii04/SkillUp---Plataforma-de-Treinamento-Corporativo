namespace SkillUp.Domain.Entities
{
    public class Questao
    {
        public Guid Id { get; set; }
        public string Enunciado { get; set; } = null!;
        public int Peso { get; set; } = 1;
        public string? Explicacao { get; set; }

        public Guid CursoId { get; set; }
        public Curso Curso { get; set; } = null!;

        public List<Opcao> Opcoes { get; set; } = new();
    }

    public class Opcao
    {
        public Guid Id { get; set; }
        public string Texto { get; set; } = null!;
        public bool Correta { get; set; }

        public Guid QuestaoId { get; set; }
        public Questao Questao { get; set; } = null!;
    }
}
