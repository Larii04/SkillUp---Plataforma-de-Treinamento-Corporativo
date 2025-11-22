using Microsoft.EntityFrameworkCore;
using SkillUp.Domain.Entities;

namespace SkillUp.Application.Persistence
{
    // Abstração do DbContext para uso pela camada de aplicação
    public interface ISkillUpContext
    {
        DbSet<Usuario> Usuarios { get; }
        DbSet<Curso> Cursos { get; }
        DbSet<Modulo> Modulos { get; }
        DbSet<Licao> Licoes { get; }
        DbSet<Questao> Questoes { get; }
        DbSet<Opcao> Opcoes { get; }
        DbSet<ProgressoCursoUsuario> ProgressoCursos { get; }
        DbSet<ProgressoLicaoUsuario> ProgressoLicoes { get; }
        DbSet<TentativaQuestionarioUsuario> TentativasQuestionario { get; }
        DbSet<Certificado> Certificados { get; }
        DbSet<PontuacaoUsuario> Pontuacoes { get; }
        DbSet<InsigniaUsuario> Insignias { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
