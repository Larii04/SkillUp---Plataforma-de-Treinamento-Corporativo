using Microsoft.EntityFrameworkCore;
using SkillUp.Application.Services;
using SkillUp.Domain.Entities;
using SkillUp.Infra.Persistence;

namespace SkillUp.Infra.Services
{
    public class ProgressoService : IProgressoService
    {
        private readonly SkillUpContext _context;
        private readonly ICertificadoService _certificadoService;

        public ProgressoService(SkillUpContext context, ICertificadoService certificadoService)
        {
            _context = context;
            _certificadoService = certificadoService;
        }

        public async Task ConcluirLicaoAsync(Guid usuarioId, Guid licaoId)
        {
            var licao = await _context.Licoes
                .Include(l => l.Modulo)
                .ThenInclude(m => m.Curso)
                .FirstOrDefaultAsync(l => l.Id == licaoId);

            if (licao == null)
                throw new Exception("Lição não encontrada");

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == usuarioId);
            if (usuario == null)
                throw new Exception("Usuário não encontrado");

            var progressoLicao = await _context.ProgressoLicoes
                .FirstOrDefaultAsync(p => p.UsuarioId == usuarioId && p.LicaoId == licaoId);

            if (progressoLicao == null)
            {
                progressoLicao = new ProgressoLicaoUsuario
                {
                    Id = Guid.NewGuid(),
                    UsuarioId = usuarioId,
                    LicaoId = licaoId,
                    Concluida = true,
                    DataConclusao = DateTime.UtcNow
                };
                _context.ProgressoLicoes.Add(progressoLicao);
            }
            else
            {
                progressoLicao.Concluida = true;
                progressoLicao.DataConclusao = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();

            var cursoId = licao.Modulo.CursoId;

            var totalLicoesCurso = await _context.Licoes
                .Include(l => l.Modulo)
                .CountAsync(l => l.Modulo.CursoId == cursoId);

            var licoesConcluidasUsuario = await _context.ProgressoLicoes
                .Include(p => p.Licao)
                .ThenInclude(l => l.Modulo)
                .CountAsync(p => p.UsuarioId == usuarioId 
                              && p.Concluida 
                              && p.Licao.Modulo.CursoId == cursoId);

            var percentual = totalLicoesCurso == 0 
                ? 0 
                : (decimal)licoesConcluidasUsuario / totalLicoesCurso * 100;

            var progressoCurso = await _context.ProgressoCursos
                .FirstOrDefaultAsync(p => p.UsuarioId == usuarioId && p.CursoId == cursoId);

            var concluiuAgora = false;

            if (progressoCurso == null)
            {
                progressoCurso = new ProgressoCursoUsuario
                {
                    Id = Guid.NewGuid(),
                    UsuarioId = usuarioId,
                    CursoId = cursoId,
                    Percentual = percentual,
                    Concluido = percentual >= 100,
                    DataConclusao = percentual >= 100 ? DateTime.UtcNow : null
                };
                _context.ProgressoCursos.Add(progressoCurso);
                concluiuAgora = progressoCurso.Concluido;
            }
            else
            {
                progressoCurso.Percentual = percentual;

                if (!progressoCurso.Concluido && percentual >= 100)
                {
                    progressoCurso.Concluido = true;
                    progressoCurso.DataConclusao = DateTime.UtcNow;
                    concluiuAgora = true;
                }
            }

            await _context.SaveChangesAsync();

            if (concluiuAgora)
            {
                await _certificadoService.GerarCertificadoAsync(usuarioId, cursoId);
            }
        }
    }
}
