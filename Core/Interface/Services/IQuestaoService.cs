using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Services
{
    public interface IQuestaoService : IService<Questao>
    {
        List<Questao> GetByCadernoId(int cadernoId);
    }
}
