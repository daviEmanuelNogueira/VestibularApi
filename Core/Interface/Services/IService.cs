using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Services
{
    public interface IService<T> where T : class
    {
        void Create(T entidade);
        void Update(T entidade);
        void Delete(T entidade);
        List<T> GetAll<T>(params Expression<Func<T, object>>[] includeProperties) where T : class;
        T GetById<T>(int id, params Expression<Func<T, object>>[] includeProperties) where T : Entity;
    }
}

