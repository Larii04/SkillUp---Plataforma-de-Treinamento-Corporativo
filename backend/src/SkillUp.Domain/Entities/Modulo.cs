namespace SkillUp.Domain.Entities
{
    public class Modulo
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public int Ordem { get; set; }

        public Guid CursoId { get; set; }
        public Curso Curso { get; set; } = null!;

        public List<Licao> Licoes { get; set; } = new();
    }
}
