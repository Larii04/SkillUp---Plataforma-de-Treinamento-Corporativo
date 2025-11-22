using SkillUp.Domain.Enums;

namespace SkillUp.Domain.Entities
{
    public class PontuacaoUsuario
    {
        public Guid Id { get; set; }
        public int Pontos { get; set; }
        public string Motivo { get; set; } = null!;
        public DateTime DataRegistro { get; set; }

        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;
    }

    public class InsigniaUsuario
    {
        public Guid Id { get; set; }
        public TipoInsignia Tipo { get; set; }
        public DateTime DataRegistro { get; set; }

        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;
    }
}
