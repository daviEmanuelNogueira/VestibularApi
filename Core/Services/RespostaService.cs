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
    public class RespostaService : IRespostaService
    {
        private readonly IRespostaRepository _respostaRepository;

        public RespostaService(IRespostaRepository respostaRepository)
        {
            _respostaRepository = respostaRepository;
        }

        public void Create(Resposta entidade)
        {
            throw new NotImplementedException();
        }

        public void Delete(Resposta entidade)
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

        public List<Resposta> GetByProvaId(int provaId)
        {
            return _respostaRepository.GetByProvaId(provaId);
        }

        public void Update(Resposta entidade)
        {
            throw new NotImplementedException();
        }
    }
}
