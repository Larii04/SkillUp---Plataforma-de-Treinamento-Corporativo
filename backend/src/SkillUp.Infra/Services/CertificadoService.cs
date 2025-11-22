using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SkillUp.Application.Services;
using SkillUp.Domain.Entities;
using SkillUp.Infra.Persistence;

namespace SkillUp.Infra.Services
{
    public class CertificadoService : ICertificadoService
    {
        private readonly SkillUpContext _context;
        private readonly IEmailService _emailService;
        private readonly IHostEnvironment _env;

        public CertificadoService(
            SkillUpContext context,
            IEmailService emailService,
            IHostEnvironment env)
        {
            _context = context;
            _emailService = emailService;
            _env = env;
        }

        public async Task<Certificado> GerarCertificadoAsync(Guid usuarioId, Guid cursoId)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == usuarioId)
                ?? throw new Exception("Usuário não encontrado");

            var curso = await _context.Cursos.FirstOrDefaultAsync(c => c.Id == cursoId)
                ?? throw new Exception("Curso não encontrado");

            var certificado = new Certificado
            {
                Id = Guid.NewGuid(),
                UsuarioId = usuarioId,
                CursoId = cursoId,
                DataGeracao = DateTime.UtcNow,
                HashVerificacao = Guid.NewGuid().ToString("N")
            };

            var pastaCertificados = Path.Combine(_env.ContentRootPath, "CertificadosGerados");
            Directory.CreateDirectory(pastaCertificados);

            var caminhoPdf = Path.Combine(pastaCertificados, $"{certificado.Id}.pdf");
            certificado.CaminhoPdf = caminhoPdf;

            var pastaTemplates = Path.Combine(_env.ContentRootPath, "Templates");
            Directory.CreateDirectory(pastaTemplates);
            var caminhoImagem = Path.Combine(pastaTemplates, "certificado_base.png");

            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(20);
                    page.PageColor(Colors.White);

                    page.Content().Stack(stack =>
                    {
                        if (File.Exists(caminhoImagem))
                        {
                            stack.Item()
                                .AlignCenter()
                                .AlignMiddle()
                                .Image(caminhoImagem, ImageScaling.FitArea);
                        }

                        stack.Item().Padding(40).AlignCenter().Column(col =>
                        {
                            col.Item().Text("CERTIFICADO DE CONCLUSÃO")
                                .FontSize(24).Bold();

                            col.Item().Text($"Concedido a: {usuario.Nome}")
                                .FontSize(18);

                            col.Item().Text($"Pela conclusão do curso: {curso.Nome}")
                                .FontSize(16);

                            col.Item().Text($"Data: {DateTime.UtcNow:dd/MM/yyyy}")
                                .FontSize(14);

                            col.Item().Text($"Código de verificação: {certificado.HashVerificacao}")
                                .FontSize(10);
                        });
                    });
                });
            }).GeneratePdf(caminhoPdf);

            _context.Certificados.Add(certificado);
            await _context.SaveChangesAsync();

            var bytes = await File.ReadAllBytesAsync(caminhoPdf);

            await _emailService.EnviarAsync(
                usuario.Email,
                "Seu certificado de conclusão",
                $"Olá {usuario.Nome},\n\nParabéns pela conclusão do curso \"{curso.Nome}\"! Em anexo, está o seu certificado.",
                bytes,
                "certificado.pdf"
            );

            return certificado;
        }
    }
}
