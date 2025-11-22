using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillUp.Application.Services;

namespace SkillUp.Api.Controllers
{
    [ApiController]
    [Route("certificados")]
    public class CertificadoController : ControllerBase
    {
        private readonly ICertificadoService _certificadoService;
        private readonly ILogger<CertificadoController> _logger;

        public CertificadoController(
            ICertificadoService certificadoService,
            ILogger<CertificadoController> logger)
        {
            _certificadoService = certificadoService;
            _logger = logger;
        }

        /// <summary>
        /// Gera um certificado de teste e retorna o PDF.
        /// </summary>
        [Authorize] // opcional
        [HttpGet("testar/{usuarioId}/{cursoId}")]
        public async Task<IActionResult> TestarCertificado(Guid usuarioId, Guid cursoId)
        {
            var certificado = await _certificadoService.GerarCertificadoAsync(usuarioId, cursoId);

            var bytes = await System.IO.File.ReadAllBytesAsync(certificado.CaminhoPdf);

            return File(bytes, "application/pdf", "certificado-teste.pdf");
        }
    }
}
