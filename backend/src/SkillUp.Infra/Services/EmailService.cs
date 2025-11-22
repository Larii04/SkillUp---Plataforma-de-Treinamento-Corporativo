using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Microsoft.Extensions.Configuration;
using SkillUp.Application.Services;

namespace SkillUp.Infra.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task EnviarAsync(string para, string assunto, string corpo, byte[]? anexo = null, string? nomeAnexo = null)
        {
            var mensagem = new MimeMessage();

            var secao = _configuration.GetSection("Email");

            var remetenteNome = secao["RemetenteNome"] ?? "SkillUp";
            var remetenteEmail = secao["RemetenteEmail"] ?? "no-reply@skillup.com";

            mensagem.From.Add(new MailboxAddress(remetenteNome, remetenteEmail));
            mensagem.To.Add(MailboxAddress.Parse(para));
            mensagem.Subject = assunto;

            var builder = new BodyBuilder
            {
                TextBody = corpo
            };

            if (anexo != null && !string.IsNullOrWhiteSpace(nomeAnexo))
            {
                builder.Attachments.Add(nomeAnexo, anexo);
            }

            mensagem.Body = builder.ToMessageBody();

            using var client = new SmtpClient();
            var host = secao["Host"] ?? "";
            var portaStr = secao["Porta"] ?? "587";
            var usuario = secao["Usuario"];
            var senha = secao["Senha"];

            if (string.IsNullOrWhiteSpace(host))
                return;

            var porta = int.Parse(portaStr);

            await client.ConnectAsync(host, porta, SecureSocketOptions.StartTls);
            if (!string.IsNullOrEmpty(usuario))
            {
                await client.AuthenticateAsync(usuario, senha);
            }

            await client.SendAsync(mensagem);
            await client.DisconnectAsync(true);
        }
    }
}
