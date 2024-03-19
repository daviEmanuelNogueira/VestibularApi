using Core;
using Core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumidor.Service
{
    
    public class CreateProvaService
    {
        private readonly IProvaService _provaService;

        public CreateProvaService(IProvaService provaService)
        {
            _provaService = provaService;
        }

        public void CreateProva(Prova prova)
        {
            var provaEntidade = new Prova(prova.AlunoId, prova.CadernoId);
            provaEntidade.SetRespostas(prova.Respostas);
            _provaService.Create(provaEntidade);
        }
    }
}
