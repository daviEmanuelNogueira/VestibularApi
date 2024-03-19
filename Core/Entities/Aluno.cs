using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Aluno : Entity
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CadernoId { get; set; }
        public decimal Pontuacao { get; set; }

        //EF. Rel
        public Prova Prova { get; set; }
        public Caderno Caderno { get; set; }

        protected Aluno() { }
        public Aluno(string nome, DateTime dataCadastro, string cPF)
        {
            Nome = nome;
            DataCadastro = dataCadastro;
            CPF = cPF;
        }

        public void SetCadernoAluno(int cadernoId)
        {
            CadernoId = cadernoId;
        }

        internal void SetPontuacao(int pontuacao)
        {
            Pontuacao = pontuacao;
        }
    }
}
