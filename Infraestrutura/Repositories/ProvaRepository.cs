using Core;
using Core.Interface;
using Infraestrutura.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositories
{
    public class ProvaRepository : Repository<Prova>, IProvaRepository
    {
        public ProvaRepository(VestibularContext context) : base(context)
        {
                
        }

        public Prova GetByAlunoId(int alunoId)
        {
            return _dbSet.Where(x => x.AlunoId == alunoId).FirstOrDefault();
        }
    }
}
