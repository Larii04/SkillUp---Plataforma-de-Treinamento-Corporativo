using Microsoft.EntityFrameworkCore;
using SkillUp.Application.Questionarios.Commands;
using SkillUp.Application.Questionarios.Responses;
using SkillUp.Application.Services;
using SkillUp.Domain.Entities;
using SkillUp.Infra.Persistence;
using System.Text.Json;

namespace SkillUp.Infra.Services
{
    public class QuestionarioService : IQuestionarioService
    {
        private readonly SkillUpContext _context;

        public QuestionarioService(SkillUpContext context)
        {
            _context = context;
        }

        public async Task<QuestionarioCursoResponse> ObterQuestionarioCursoAsync(Guid cursoId)
        {
            var curso = await _context.Cursos.FirstOrDefaultAsync(c => c.Id == cursoId)
                ?? throw new Exception("Curso não encontrado");

            var questoes = await _context.Questoes
                .Include(q => q.Opcoes)
                .Where(q => q.CursoId == cursoId)
                .ToListAsync();

            var response = new QuestionarioCursoResponse
            {
                CursoId = cursoId,
                NomeCurso = curso.Nome,
                Questoes = questoes.Select(q => new QuestaoResponse
                {
                    Id = q.Id,
                    Enunciado = q.Enunciado,
                    Explicacao = q.Explicacao,
                    Opcoes = q.Opcoes.Select(o => new OpcaoResponse
                    {
                        Id = o.Id,
                        Texto = o.Texto
                    }).ToList()
                }).ToList()
            };

            return response;
        }

        public async Task<ResultadoQuestionarioResponse> ProcessarRespostasAsync(Guid usuarioId, Guid cursoId, List<RespostaQuestaoItem> respostas)
        {
            var questoes = await _context.Questoes
                .Include(q => q.Opcoes)
                .Where(q => q.CursoId == cursoId)
                .ToListAsync();

            var totalQuestoes = questoes.Count;
            var acertos = 0;

            var detalhes = new List<object>();

            foreach (var questao in questoes)
            {
                var resposta = respostas.FirstOrDefault(r => r.QuestaoId == questao.Id);
                if (resposta == null)
                {
                    detalhes.Add(new { questaoId = questao.Id, correto = false });
                    continue;
                }

                var opcaoCorreta = questao.Opcoes.FirstOrDefault(o => o.Correta);
                var acertou = opcaoCorreta != null && opcaoCorreta.Id == resposta.OpcaoId;
                if (acertou) acertos++;

                detalhes.Add(new
                {
                    questaoId = questao.Id,
                    respostaId = resposta.OpcaoId,
                    correta = acertou
                });
            }

            var nota = totalQuestoes == 0
                ? 0
                : Math.Round((decimal)acertos / totalQuestoes * 10, 2);

            var aprovado = nota >= 7;

            var tentativa = new TentativaQuestionarioUsuario
            {
                Id = Guid.NewGuid(),
                UsuarioId = usuarioId,
                CursoId = cursoId,
                TotalQuestoes = totalQuestoes,
                Acertos = acertos,
                Nota = nota,
                DataTentativa = DateTime.UtcNow,
                JsonRespostas = JsonSerializer.Serialize(detalhes)
            };

            _context.TentativasQuestionario.Add(tentativa);
            await _context.SaveChangesAsync();

            return new ResultadoQuestionarioResponse
            {
                TotalQuestoes = totalQuestoes,
                Acertos = acertos,
                Nota = nota,
                Aprovado = aprovado,
                Mensagem = aprovado ? "Parabéns! Você foi aprovado." : "Você não atingiu a nota mínima."
            };
        }
    }
}
