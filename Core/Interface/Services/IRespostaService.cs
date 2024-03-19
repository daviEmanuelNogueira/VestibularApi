﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Services
{
    public interface IRespostaService : IService<Resposta>
    {
        List<Resposta> GetByProvaId(int provaId);
    }
}
