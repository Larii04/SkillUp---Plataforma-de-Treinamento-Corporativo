namespace SkillUp.Application.Questionarios.Responses
{
    public class QuestionarioCursoResponse
    {
        public Guid CursoId { get; set; }
        public string NomeCurso { get; set; } = null!;
        public List<QuestaoResponse> Questoes { get; set; } = new();
    }
}
