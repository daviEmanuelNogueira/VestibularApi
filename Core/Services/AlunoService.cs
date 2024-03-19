using Core.Interface;
using Core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IProvaService _provaService;
        private readonly IQuestaoService _questaoService;
        private readonly IRespostaService _respostaService;

        public AlunoService(IAlunoRepository alunoRepository, IProvaService provaService, IQuestaoService questaoService, IRespostaService respostaService)
        {
            _alunoRepository = alunoRepository;
            _provaService = provaService;
            _questaoService = questaoService;
            _respostaService = respostaService;
        }

        public void Create(Aluno aluno)
        {
            _alunoRepository.Create(aluno);
        }

        public void Delete(Aluno entidade)
        {
            throw new NotImplementedException();
        }

        public List<Aluno> GetAll()
        {
            return _alunoRepository.GetAll<Aluno>();
        }

        public T GetById<T>(int id, params Expression<Func<T, object>>[] includeProperties) where T : Entity
        {
            throw new NotImplementedException();
        }

        public int AvaliarAluno(int alunoId)
        {
            var aluno = _alunoRepository.GetById<Aluno>(alunoId);
            var prova = _provaService.GetByAlunoId(alunoId);
            var pontuacao = 0;

            if (prova != null)
            {
                List<Questao> questoes = _questaoService.GetByCadernoId(prova.CadernoId);
                List<Resposta> respostas = _respostaService.GetByProvaId(prova.Id);
                Dictionary<int, string> respostasCorretas = questoes.ToDictionary(q => q.Id, q => q.RespostaCorreta);

                // Filtrando as respostas que correspondem às respostas corretas
                List<Questao> respostasCertas = new List<Questao>();
                foreach (var resposta in respostas)
                {
                    if (respostasCorretas.TryGetValue(resposta.NumeroQuestao, out string respostaCorreta) && respostaCorreta == resposta.AlternativaEscolhida)
                    {
                        var questao = questoes.FirstOrDefault(q => q.Id == resposta.NumeroQuestao);
                        if (questao != null)
                            respostasCertas.Add(questao);
                    }
                }

                pontuacao = respostasCertas.Count();
            }

            aluno.SetPontuacao(pontuacao);
            _alunoRepository.Update(aluno);

            return pontuacao;
        }

        public void Update(Aluno entidade)
        {
            throw new NotImplementedException();
        }
    }
}
