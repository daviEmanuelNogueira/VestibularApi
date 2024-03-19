namespace Core;
public class Questao : Entity
{
    public Questao(int id, int numeroQuestao, int cadernoId, string descricao, string alternativaA, string alternativaB, string alternativaC, string alternativaD, string respostaCorreta)
    {
        Id = id;
        NumeroQuestao = numeroQuestao;
        CadernoId = cadernoId;
        Descricao = descricao;
        AlternativaA = alternativaA;
        AlternativaB = alternativaB;
        AlternativaC = alternativaC;
        AlternativaD = alternativaD;
        RespostaCorreta = respostaCorreta;
    }

    protected Questao() { }

    public int CadernoId { get; set; }
    public int NumeroQuestao { get; set; }
    public string Descricao { get; set; }
    public string AlternativaA { get; set; }
    public string AlternativaB { get; set; }
    public string AlternativaC { get; set; }
    public string AlternativaD { get; set; }
    public string RespostaCorreta { get; set; }

    //Ef.Rel
    public Caderno Caderno {  get; set; }   
}
