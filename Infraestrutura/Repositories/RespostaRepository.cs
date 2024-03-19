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
    public class RespostaRepository : Repository<Resposta>, IRespostaRepository
    {
        public RespostaRepository(VestibularContext context) : base(context)
        {
                
        }

        public List<Resposta> GetByProvaId(int provaId)
        {
            return _dbSet.Where(x => x.ProvaId == provaId).ToList();
        }
    }
}
