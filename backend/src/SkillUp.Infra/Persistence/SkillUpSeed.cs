using Microsoft.EntityFrameworkCore;
using SkillUp.Domain.Entities;
using SkillUp.Domain.Enums;

namespace SkillUp.Infra.Persistence
{
    public static class SkillUpSeed
    {
        public static async Task SeedAsync(SkillUpContext context)
        {
            await context.Database.MigrateAsync();

            if (!context.Usuarios.Any())
            {
                var admin = new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = "Administrador",
                    Email = "admin@skillup.com",
                    SenhaHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    Papel = PapelUsuario.Admin
                };

                var colaborador = new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = "Colaborador Teste",
                    Email = "colaborador@skillup.com",
                    SenhaHash = BCrypt.Net.BCrypt.HashPassword("colab123"),
                    Papel = PapelUsuario.Colaborador
                };

                context.Usuarios.AddRange(admin, colaborador);
            }

            if (!context.Cursos.Any())
            {
                var curso = new Curso
                {
                    Id = Guid.NewGuid(),
                    Nome = "Onboarding da Empresa",
                    Descricao = "Curso introdutório de boas-vindas.",
                    Categoria = "Institucional",
                    Nivel = NivelCurso.Iniciante,
                    Publicado = true
                };

                var modulo1 = new Modulo
                {
                    Id = Guid.NewGuid(),
                    Nome = "Introdução",
                    Ordem = 1,
                    Curso = curso
                };

                var modulo2 = new Modulo
                {
                    Id = Guid.NewGuid(),
                    Nome = "Políticas Internas",
                    Ordem = 2,
                    Curso = curso
                };

                var licao1 = new Licao
                {
                    Id = Guid.NewGuid(),
                    Modulo = modulo1,
                    Titulo = "Bem-vindo à empresa",
                    Tipo = TipoLicao.Video,
                    UrlConteudo = "https://video.exemplo.com/onboarding1",
                    Ordem = 1,
                    RequerQuestionario = false
                };

                var licao2 = new Licao
                {
                    Id = Guid.NewGuid(),
                    Modulo = modulo2,
                    Titulo = "Código de Conduta",
                    Tipo = TipoLicao.Pdf,
                    UrlConteudo = "/arquivos/codigoconduta.pdf",
                    Ordem = 1,
                    RequerQuestionario = true
                };

                var questao1 = new Questao
                {
                    Id = Guid.NewGuid(),
                    Curso = curso,
                    Enunciado = "É obrigatório ler o código de conduta?",
                    Peso = 1,
                    Explicacao = "A leitura é fundamental para conhecer as regras."
                };

                var opcao1 = new Opcao
                {
                    Id = Guid.NewGuid(),
                    Questao = questao1,
                    Texto = "Sim, é obrigatório",
                    Correta = true
                };

                var opcao2 = new Opcao
                {
                    Id = Guid.NewGuid(),
                    Questao = questao1,
                    Texto = "Não, é opcional",
                    Correta = false
                };

                curso.Modulos.Add(modulo1);
                curso.Modulos.Add(modulo2);
                modulo1.Licoes.Add(licao1);
                modulo2.Licoes.Add(licao2);
                curso.Questoes.Add(questao1);
                questao1.Opcoes.Add(opcao1);
                questao1.Opcoes.Add(opcao2);

                context.Cursos.Add(curso);
            }

            await context.SaveChangesAsync();
        }
    }
}
