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
    public class CadernoService: ICadernoService
    {
        private readonly ICadernoRepository _cadernoRepository;

    public CadernoService(ICadernoRepository CadernoRepository)
    {
        _cadernoRepository = CadernoRepository;
    }

    public void Create(Caderno Caderno)
    {
        _cadernoRepository.Create(Caderno);
    }

    public void Delete(Caderno entidade)
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

    public void Update(Caderno entidade)
    {
        throw new NotImplementedException();
    }
}
}
