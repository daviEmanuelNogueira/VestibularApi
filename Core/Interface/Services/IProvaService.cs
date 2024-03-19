﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Services
{
    public interface IProvaService : IService<Prova>
    {
        Prova GetByAlunoId(int alunoId);
    }
}
