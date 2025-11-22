using MediatR;
using SkillUp.Application.Questionarios.Commands;
using SkillUp.Application.Questionarios.Responses;
using SkillUp.Application.Services;

namespace SkillUp.Application.Questionarios.Handlers
{
    public class ResponderQuestionarioCommandHandler 
        : IRequestHandler<ResponderQuestionarioCommand, ResultadoQuestionarioResponse>
    {
        private readonly IQuestionarioService _questionarioService;

        public ResponderQuestionarioCommandHandler(IQuestionarioService questionarioService)
        {
            _questionarioService = questionarioService;
        }

        public async Task<ResultadoQuestionarioResponse> Handle(ResponderQuestionarioCommand request, CancellationToken cancellationToken)
        {
            return await _questionarioService.ProcessarRespostasAsync(request.UsuarioId, request.CursoId, request.Respostas);
        }
    }
}
