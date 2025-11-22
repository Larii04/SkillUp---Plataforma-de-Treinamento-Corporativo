using SkillUp.Application.Questionarios.Commands;
using SkillUp.Application.Questionarios.Responses;

namespace SkillUp.Application.Services
{
    public interface IQuestionarioService
    {
        Task<QuestionarioCursoResponse> ObterQuestionarioCursoAsync(Guid cursoId);
        Task<ResultadoQuestionarioResponse> ProcessarRespostasAsync(Guid usuarioId, Guid cursoId, List<RespostaQuestaoItem> respostas);
    }
}
