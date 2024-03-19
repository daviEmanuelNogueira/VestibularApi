namespace Core;

public class Resposta : Entity
{
    public Resposta(int provaId, string alternativaEscolhida, int numeroQuestao)
    {
        ProvaId = provaId;
        AlternativaEscolhida = alternativaEscolhida;
        NumeroQuestao = numeroQuestao;  
    }
    protected Resposta() { }  

    public int ProvaId { get; set; }
    public int NumeroQuestao { get; set; }
    public string AlternativaEscolhida { get; set; }

    //EF. Rel
    public Prova Prova { get; set; }
}
