using Microsoft.EntityFrameworkCore;
using SkillUp.Domain.Entities;

namespace SkillUp.Infra.Persistence
{
    public class SkillUpContext : DbContext
    {
        public SkillUpContext(DbContextOptions<SkillUpContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Curso> Cursos => Set<Curso>();
        public DbSet<Modulo> Modulos => Set<Modulo>();
        public DbSet<Licao> Licoes => Set<Licao>();
        public DbSet<Questao> Questoes => Set<Questao>();
        public DbSet<Opcao> Opcoes => Set<Opcao>();
        public DbSet<ProgressoCursoUsuario> ProgressoCursos => Set<ProgressoCursoUsuario>();
        public DbSet<ProgressoLicaoUsuario> ProgressoLicoes => Set<ProgressoLicaoUsuario>();
        public DbSet<TentativaQuestionarioUsuario> TentativasQuestionario => Set<TentativaQuestionarioUsuario>();
        public DbSet<Certificado> Certificados => Set<Certificado>();
        public DbSet<PontuacaoUsuario> Pontuacoes => Set<PontuacaoUsuario>();
        public DbSet<InsigniaUsuario> Insignias => Set<InsigniaUsuario>();
    }
}
