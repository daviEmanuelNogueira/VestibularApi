namespace Core;

public class Prova : Entity
{

    public int AlunoId { get; set; }
    public int CadernoId { get; set; }

    //EF. Rel
    public Caderno Caderno { get; set; }    
    public List<Resposta> Respostas { get; set; }
    public Aluno Aluno { get; set; }

    public Prova(int alunoId, int cadernoId)
    {
        AlunoId = alunoId;
        CadernoId = cadernoId;
    }

    protected Prova() { }

    public void SetRespostas(List<Resposta> respostas)
    {
        Respostas = respostas;
    }
}
