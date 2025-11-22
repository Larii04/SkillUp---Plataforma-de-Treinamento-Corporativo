using SkillUp.Domain.Entities;

namespace SkillUp.Application.Services
{
    public interface ICertificadoService
    {
        Task<Certificado> GerarCertificadoAsync(Guid usuarioId, Guid cursoId);
    }
}
