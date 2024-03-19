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
    public class QuestaoService : IQuestaoService
    {
        private readonly IProvaRepository _provaRepository;
        private readonly IQuestaoRepository _questaoRepository;

        public QuestaoService(IProvaRepository provaRepository, IQuestaoRepository questaoRepository)
        {
            _provaRepository = provaRepository;
            _questaoRepository = questaoRepository;
        }

        public void Create(Questao entidade)
        {
            throw new NotImplementedException();
        }

        public void Delete(Questao entidade)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>(params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(int id, params Expression<Func<T, object>>[] includeProperties) where T : Entity
        {
            throw new NotImplementedException();
        }

        public List<Questao> GetByCadernoId(int provaId)
        {
            return _questaoRepository.GetByCadernoId(provaId);
        }

        public void Update(Questao entidade)
        {
            throw new NotImplementedException();
        }
    }
}
