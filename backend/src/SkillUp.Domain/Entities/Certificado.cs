namespace SkillUp.Domain.Entities
{
    public class Certificado
    {
        public Guid Id { get; set; }

        public string CaminhoPdf { get; set; } = null!;
        public string HashVerificacao { get; set; } = null!;
        public DateTime DataGeracao { get; set; }

        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public Guid CursoId { get; set; }
        public Curso Curso { get; set; } = null!;
    }
}
