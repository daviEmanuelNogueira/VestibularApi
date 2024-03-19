namespace VestibularApi.ViewModel;

public class AlunoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime DataCadastro { get; set; }
    public int CadernoId { get; set; }
    public decimal Pontuacao { get; set; }

}
