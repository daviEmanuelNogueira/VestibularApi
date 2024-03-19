using Core;
using Core.Interface.Services;
using Microsoft.AspNetCore.Mvc;
using VestibularApi.ViewModel;

namespace VestibularApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlunoController : ControllerBase
{
    private readonly IAlunoService _alunoService;

    public AlunoController(IAlunoService alunoService)
    {
        _alunoService = alunoService;
    }

    [HttpPost("CreateAluno")]
    public IActionResult CreateAluno(AlunoViewModel alunoViewModel)
    {
        var aluno = new Aluno(alunoViewModel.Nome, alunoViewModel.DataCadastro, alunoViewModel.CPF);

        aluno.SetCadernoAluno(alunoViewModel.CadernoId);

        _alunoService.Create(aluno);

        return Ok("Aluno Cadastrado");
    }

    [HttpGet("AvaliarAluno")]
    public IActionResult AvaliarAluno(int alunoId)
    {
        int pontuacaoAluno = _alunoService.AvaliarAluno(alunoId);

        return Ok($"A pontuação deste aluno foi: {pontuacaoAluno}");
    }
}
