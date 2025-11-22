using SkillUp.Domain.Enums;

namespace SkillUp.Domain.Entities
{
    public class Licao
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = null!;
        public TipoLicao Tipo { get; set; }

        public string? UrlConteudo { get; set; }
        public string? ConteudoTexto { get; set; }
        public bool RequerQuestionario { get; set; }

        public int Ordem { get; set; }
        public int? MinutosEstimados { get; set; }

        public Guid ModuloId { get; set; }
        public Modulo Modulo { get; set; } = null!;
    }
}
