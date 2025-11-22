namespace SkillUp.Domain.Entities
{
    public class ProgressoLicaoUsuario
    {
        public Guid Id { get; set; }
        public bool Concluida { get; set; }
        public DateTime? DataConclusao { get; set; }

        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public Guid LicaoId { get; set; }
        public Licao Licao { get; set; } = null!;
    }

    public class ProgressoCursoUsuario
    {
        public Guid Id { get; set; }
        public decimal Percentual { get; set; }
        public bool Concluido { get; set; }
        public DateTime? DataConclusao { get; set; }

        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public Guid CursoId { get; set; }
        public Curso Curso { get; set; } = null!;
    }
}
