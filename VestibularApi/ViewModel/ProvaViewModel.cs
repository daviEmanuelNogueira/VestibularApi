using Core;

namespace VestibularApi.ViewModel;

public class ProvaViewModel
{
    public int AlunoId { get; set; }
    public int CadernoId { get; set; }
    public List<RespostasViewModel> Respostas { get; set; }

    public ProvaViewModel()
    {
    }

    public ProvaViewModel(int alunoId, int cadernoId, List<RespostasViewModel> respostas)
    {
        AlunoId = alunoId;
        CadernoId = cadernoId;
        Respostas = respostas;

        if (alunoId <= 0)
            throw new ArgumentException("Um AlunoId precisa ser informado!");

        if (cadernoId <= 0)
            throw new ArgumentException("Um CadernoId precisa ser informado!");

        List<string> alternativasValidas = new List<string> { "A", "B", "C", "D" };

        foreach (var resposta in Respostas)
        {
            if (resposta.NumeroQuestao <= 0)
                throw new ArgumentException("Um Numero de Questão precisa ser informado!");

            if (string.IsNullOrEmpty(resposta.AlternativaEscolhida) || !alternativasValidas.Contains(resposta.AlternativaEscolhida))
                throw new ArgumentException($"A Resposta do aluno deve ser uma dessas opções: { string.Join(", ", alternativasValidas) }!");
        }
    }
}
