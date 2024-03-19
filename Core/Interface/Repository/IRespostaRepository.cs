using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IRespostaRepository : IRepository<Resposta>
    {
        List<Resposta> GetByProvaId(int provaId);
    }
}
