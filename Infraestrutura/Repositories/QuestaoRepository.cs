using Core.Interface;
using Core;
using Infraestrutura.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositories
{
    public class QuestaoRepository : Repository<Questao>, IQuestaoRepository
    {
        public QuestaoRepository(VestibularContext context) : base(context)
        {

        }

        public List<Questao> GetByCadernoId(int cadernoId)
        {
            return _dbSet.Where(x => x.CadernoId == cadernoId).ToList();
        }
    }
}
