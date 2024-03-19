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
    public class ProvaService : IProvaService
    {
        private readonly IProvaRepository _provaRepository;
        private readonly IRespostaRepository _respostaRepository;

        public ProvaService(IProvaRepository provaRepository, IRespostaRepository respostaRepository)
        {
            _provaRepository = provaRepository;
            _respostaRepository = respostaRepository;
        }

        public void Create(Prova prova)
        {
            _provaRepository.Create(prova);
        }

        public void Delete(Prova entidade)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>(params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            throw new NotImplementedException();
        }

        public Prova GetByAlunoId(int alunoId)
        {
            return _provaRepository.GetByAlunoId(alunoId);
        }

        public T GetById<T>(int id, params Expression<Func<T, object>>[] includeProperties) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Update(Prova entidade)
        {
            throw new NotImplementedException();
        }
    }
}
