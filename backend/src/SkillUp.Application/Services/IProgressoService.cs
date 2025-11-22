namespace SkillUp.Application.Services
{
    public interface IProgressoService
    {
        Task ConcluirLicaoAsync(Guid usuarioId, Guid licaoId);
    }
}
