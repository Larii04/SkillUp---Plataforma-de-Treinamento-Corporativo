namespace SkillUp.Application.Questionarios.Responses
{
    public class ResultadoQuestionarioResponse
    {
        public int TotalQuestoes { get; set; }
        public int Acertos { get; set; }
        public decimal Nota { get; set; }
        public bool Aprovado { get; set; }
        public string? Mensagem { get; set; }
    }
}
