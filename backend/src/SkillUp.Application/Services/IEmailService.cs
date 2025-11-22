namespace SkillUp.Application.Services
{
    public interface IEmailService
    {
        Task EnviarAsync(string para, string assunto, string corpo, byte[]? anexo = null, string? nomeAnexo = null);
    }
}
