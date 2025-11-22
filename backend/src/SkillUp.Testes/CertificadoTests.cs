using Xunit;
using SkillUp.Infra.Services;
using SkillUp.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Moq;
using System.IO;
using SkillUp.Application.Services;
using SkillUp.Domain.Entities;

public class CertificadoTests
{
    [Fact]
    public async Task DeveGerarCertificadoPdf()
    {
        // Mock ambiente
        var env = new Mock<IHostEnvironment>();
        env.Setup(x => x.ContentRootPath).Returns(Directory.GetCurrentDirectory());

        // Banco em memória
        var options = new DbContextOptionsBuilder<SkillUpContext>()
            .UseInMemoryDatabase("CertificadoTestDB")
            .Options;

        var ctx = new SkillUpContext(options);

        // Seed de dados
        var usuario = new Usuario
        {
            Id = Guid.NewGuid(),
            Nome = "Maria Silva Santos",
            Email = "maria@empresa.com",
            SenhaHash = "HASH",
            Papel = PapelUsuario.Colaborador
        };

        var curso = new Curso
        {
            Id = Guid.NewGuid(),
            Nome = "Segurança no Trabalho - NR10",
            Categoria = "Segurança",
            Nivel = NivelCurso.Intermediario
        };

        ctx.Usuarios.Add(usuario);
        ctx.Cursos.Add(curso);
        await ctx.SaveChangesAsync();

        // Mock envio email
        var emailService = new Mock<IEmailService>();
        emailService.Setup(x => x.EnviarAsync(It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<byte[]>(), It.IsAny<string>()))
            .Returns(Task.CompletedTask);

        var service = new CertificadoService(ctx, emailService.Object, env.Object);

        // Act
        var certificado = await service.GerarCertificadoAsync(usuario.Id, curso.Id);

        // Assert
        Assert.True(File.Exists(certificado.CaminhoPdf));
    }
}
