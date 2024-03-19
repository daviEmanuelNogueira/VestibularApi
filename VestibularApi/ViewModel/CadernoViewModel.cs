using Core;

namespace VestibularApi.ViewModel
{
    public class CadernoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public List<QuestaoViewModel> Questoes { get; set; }
        public List<ProvaViewModel> Provas { get; set; }
    }
}
