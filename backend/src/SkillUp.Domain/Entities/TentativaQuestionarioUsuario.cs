namespace SkillUp.Domain.Entities
{
    public class TentativaQuestionarioUsuario
    {
        public Guid Id { get; set; }
        public int TotalQuestoes { get; set; }
        public int Acertos { get; set; }
        public decimal Nota { get; set; }
        public string? JsonRespostas { get; set; }

        public DateTime DataTentativa { get; set; }

        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public Guid CursoId { get; set; }
        public Curso Curso { get; set; } = null!;
    }
}
