using AutoMapper;
using Core;
using Core.Interface.Services;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VestibularApi.ViewModel;

namespace VestibularApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RankingController : ControllerBase
{
    private readonly IAlunoService _alunoService;

    public RankingController(IAlunoService alunoService)
    {
        _alunoService = alunoService;
    }

    [HttpGet("RankearAlunos")]
    public IActionResult RankearAlunos()
    {
        var alunos = _alunoService.GetAll();
        List<RankViewModel> rank = new List<RankViewModel>();

        List<Aluno> alunosOrdenadosPorPontuacao = alunos.OrderByDescending(x => x.Pontuacao).ToList();

        for (int i = 0; i < alunosOrdenadosPorPontuacao.Count; i++)
        {
            rank.Add(new RankViewModel()
            {
                Nome = alunosOrdenadosPorPontuacao[i].Nome,
                Nota = alunosOrdenadosPorPontuacao[i].Pontuacao,
                Posicao = $"{i + 1}º"
            });
        }

        return Ok(rank);
    }
}
