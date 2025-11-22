namespace SkillUp.Application.Questionarios.Responses
{
    public class QuestaoResponse
    {
        public Guid Id { get; set; }
        public string Enunciado { get; set; } = null!;
        public string? Explicacao { get; set; }
        public List<OpcaoResponse> Opcoes { get; set; } = new();
    }
}
