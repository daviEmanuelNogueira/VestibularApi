using Core;
using Core.Interface;
using Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected VestibularContext _context;
        protected DbSet<T> _dbSet;
        public Repository(VestibularContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Update(T entidade)
        {
            _dbSet.Update(entidade);
            _context.SaveChanges();
        }

        public void Create(T entidade)
        {
            _dbSet.Add(entidade);
            _context.SaveChanges();
        }

        public void Delete(T entidade)
        {
            _dbSet.Remove(entidade);
            _context.SaveChanges();
        }

        public T GetById<T>(int id, params Expression<Func<T, object>>[] includeProperties) where T : Entity
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.FirstOrDefault(x => x.Id == id); // Supondo que o ID seja uma propriedade "Id" do tipo inteiro
        }

        List<T> IRepository<T>.GetAll<T>(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.ToList();
        }
    }
}
