namespace SkillUp.Application.Services
{
    public interface ITokenService
    {
        string GerarToken(Guid usuarioId, string email, string nome, string papel);
    }
}
