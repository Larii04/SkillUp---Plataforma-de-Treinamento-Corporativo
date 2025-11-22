using SkillUp.Domain.Enums;

namespace SkillUp.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome  { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string SenhaHash { get; set; } = null!;
        public PapelUsuario Papel { get; set; }

        public List<ProgressoCursoUsuario> ProgressoCursos { get; set; } = new();
        public List<ProgressoLicaoUsuario> ProgressoLicoes { get; set; } = new();
        public List<TentativaQuestionarioUsuario> Tentativas { get; set; } = new();
        public List<Certificado> Certificados { get; set; } = new();
        public List<PontuacaoUsuario> Pontuacoes { get; set; } = new();
        public List<InsigniaUsuario> Insignias { get; set; } = new();
    }
}
