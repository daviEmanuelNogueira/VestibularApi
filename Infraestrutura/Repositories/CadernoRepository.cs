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
    public class CadernoRepository: Repository<Caderno>, ICadernoRepository
    {
        public CadernoRepository(VestibularContext context) : base(context){}
    }
}
