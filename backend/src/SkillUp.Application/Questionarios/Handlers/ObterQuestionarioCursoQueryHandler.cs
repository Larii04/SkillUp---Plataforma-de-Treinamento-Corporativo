using MediatR;
using SkillUp.Application.Questionarios.Commands;
using SkillUp.Application.Questionarios.Responses;
using SkillUp.Application.Services;

namespace SkillUp.Application.Questionarios.Handlers
{
    public class ObterQuestionarioCursoQueryHandler 
        : IRequestHandler<ObterQuestionarioCursoQuery, QuestionarioCursoResponse>
    {
        private readonly IQuestionarioService _questionarioService;

        public ObterQuestionarioCursoQueryHandler(IQuestionarioService questionarioService)
        {
            _questionarioService = questionarioService;
        }

        public async Task<QuestionarioCursoResponse> Handle(ObterQuestionarioCursoQuery request, CancellationToken cancellationToken)
        {
            return await _questionarioService.ObterQuestionarioCursoAsync(request.CursoId);
        }
    }
}
