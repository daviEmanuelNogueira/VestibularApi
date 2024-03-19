using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Services
{
    public interface IAlunoService 
    {
        int AvaliarAluno(int alunoId);
        List<Aluno> GetAll();
        void Create(Aluno aluno);
    }
}
