namespace VestibularApi.ViewModel;

public class QuestaoViewModel
{
    public int Id { get; set; }
    public int NumeroQuestao { get; set; }
    public int CadernoId { get; set; }
    public string Descricao { get; set; }
    public string AlternativaA { get; set; }
    public string AlternativaB { get; set; }
    public string AlternativaC { get; set; }
    public string AlternativaD { get; set; }
    public string RespostaCorreta { get; set; }
}
