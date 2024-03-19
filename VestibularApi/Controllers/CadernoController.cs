using Core.Interface.Services;
using Core;
using Microsoft.AspNetCore.Mvc;
using VestibularApi.ViewModel;

namespace VestibularApi.Controllers
{
    public class CadernoController : Controller
    {
        private readonly ICadernoService _cadernoService;

        public CadernoController(ICadernoService cadernoService)
        {
            _cadernoService = cadernoService;
        }

        [HttpPost("CreateCaderno")]
        public IActionResult CreateCaderno(CadernoViewModel cadernoViewModel)
        {

            var caderno = new Caderno(cadernoViewModel.Id,cadernoViewModel.Nome, cadernoViewModel.Descricao);

            foreach (QuestaoViewModel questaoVM in cadernoViewModel.Questoes)
            {
                Questao questao = new Questao(
                    questaoVM.Id,
                    questaoVM.NumeroQuestao,
                    questaoVM.CadernoId,
                    questaoVM.Descricao,
                    questaoVM.AlternativaA,
                    questaoVM.AlternativaB,
                    questaoVM.AlternativaC,
                    questaoVM.AlternativaD,
                    questaoVM.RespostaCorreta
                    );

                caderno.Questoes.Add(questao);
            }

            _cadernoService.Create(caderno);

            return Ok("Caderno Cadastrado");
        }
    }
}
