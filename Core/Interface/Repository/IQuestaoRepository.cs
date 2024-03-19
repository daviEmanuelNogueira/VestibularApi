using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IQuestaoRepository : IRepository<Questao>
    {
        List<Questao> GetByCadernoId(int cadernoId);
    }
}
