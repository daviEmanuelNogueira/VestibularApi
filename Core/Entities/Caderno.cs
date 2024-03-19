namespace Core;
public class Caderno : Entity
{    protected Caderno() { }
    public Caderno(int id,string nome, string descricao)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
    }

    public string Nome { get; set; }
    public string Descricao { get; set; }

    //EF. Rel
    public List<Questao> Questoes { get; set; }
    public List<Prova> Provas { get; set; }
}
