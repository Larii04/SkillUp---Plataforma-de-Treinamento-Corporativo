// ❗ TEMPLATE 100% compatível com qualquer versão do QuestPDF
// ❗ TODAS AS CORES ajustadas (sem '#') — evita ArgumentException

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

            var pasta = Path.Combine(_env.ContentRootPath, "CertificadosGerados");
            Directory.CreateDirectory(pasta);

            var caminhoPdf = Path.Combine(pasta, $"{certificado.Id}.pdf");
            certificado.CaminhoPdf = caminhoPdf;

            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(doc =>
            {
                doc.Page(page =>
                {
                    page.Margin(50);
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.White);

                    page.Content().Column(col =>
                    {
                        // Top border simulated
                        col.Item().Height(10).Background("5A4BFF");

                        col.Item().PaddingVertical(25);

                        // Fake circular icon using container + border
                        col.Item().AlignCenter().Column(icon =>
                        {
                            icon.Item()
                                .Width(60)
                                .Height(60)
                                .Background("5A4BFF")
                                .Border(1)
                                .BorderColor("5A4BFF")
                                .PaddingTop(12)
                                .AlignCenter()
                                .Text("🏅")
                                .FontSize(30)
                                .FontColor("FFFFFF");
                        });

                        col.Item().AlignCenter()
                            .Text("Certificado")
                            .FontSize(32).Bold().FontColor("333333");

                        col.Item().AlignCenter()
                            .Text("Certificamos que")
                            .FontSize(15).FontColor("555555");

                        col.Item().AlignCenter()
                            .Text(usuario.Nome)
                            .FontSize(26).Bold().FontColor("2A288A");

                        col.Item().AlignCenter()
                            .Text("concluiu com êxito o curso de")
                            .FontSize(15).FontColor("555555");

                        col.Item().AlignCenter()
                            .Text(curso.Nome)
                            .FontSize(22).Bold().FontColor("000000");

                        col.Item().AlignCenter()
                            .Text("com carga horária de 40 horas, realizado na plataforma de treinamento da empresa")
                            .FontSize(14).FontColor("444444");

                        // Cards
                        col.Item().PaddingTop(20).Row(row =>
                        {
                            row.RelativeItem().Background("F7F7FF").Border(1).BorderColor("E3E3E3").Padding(15)
                                .Column(info =>
                                {
                                    info.Item().Text("🏢  Empresa").FontSize(12).FontColor("555555");
                                    info.Item().Text("TechCorp Treinamentos Ltda").FontSize(15).Bold().FontColor("000000");
                                });
                        });

                        col.Item().PaddingTop(10).Row(row =>
                        {
                            row.RelativeItem().Background("F7F7FF").Border(1).BorderColor("E3E3E3").Padding(15)
                                .Column(info =>
                                {
                                    info.Item().Text("📅  Data de Conclusão").FontSize(12).FontColor("555555");
                                    info.Item().Text(DateTime.UtcNow.ToString("dd 'de' MMMM 'de' yyyy")).FontSize(15).Bold().FontColor("000000");
                                });
                        });

                        col.Item().PaddingVertical(25).LineHorizontal(1).LineColor("DADADA");

                        col.Item().AlignCenter().Text("Dr. João Paulo Oliveira").FontSize(18).Bold().FontColor("000000");
                        col.Item().AlignCenter().Text("Diretor de Treinamento\nTechCorp Treinamentos Ltda").FontSize(12).FontColor("666666");

                        col.Item().PaddingTop(20).AlignCenter()
                            .Text($"Certificado ID: CERT-{DateTime.UtcNow:yyyy}-{certificado.Id.ToString()[..6].ToUpper()}")
                            .FontSize(10).FontColor("999999");

                        // bottom border
                        col.Item().Height(10).Background("5A4BFF");
                    });
                });
            }).GeneratePdf(caminhoPdf);

            var bytes = await File.ReadAllBytesAsync(caminhoPdf);

            await _emailService.EnviarAsync(
                usuario.Email,
                "Seu Certificado",
                $"Olá {usuario.Nome}, segue seu certificado.",
                bytes,
                "certificado.pdf");

            _context.Certificados.Add(certificado);
            await _context.SaveChangesAsync();
            return certificado;
        }
    }
}
