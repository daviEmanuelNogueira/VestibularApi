using AutoMapper;
using Core;
using Core.Interface.Services;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VestibularApi.ViewModel;

namespace VestibularApi.Controllers;
[Route("api/[controller]")]

[ApiController]
public class ProvaController : ControllerBase
{
    private readonly IBus _bus;
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;
    private readonly IProvaService _provaService;
    public ProvaController(IBus bus, IConfiguration config, IMapper mapper, IProvaService provaService)
    {
        _bus = bus;
        _config = config;
        _mapper = mapper;
        _provaService = provaService;
    }

    [HttpPost("CreateProva")]
    public async Task<IActionResult> CreateProva([FromBody] ProvaViewModel provaViewModel)
    {
        try
        {
            var nomeFila = _config.GetSection("MassTransitAzure")["NomeFila"] ?? string.Empty;

            var prova = new Prova(provaViewModel.AlunoId, provaViewModel.CadernoId);

            prova.SetRespostas(_mapper.Map<List<Resposta>>(provaViewModel.Respostas));

            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));

            await endpoint.Send(prova);
            return Ok("Prova enviada com sucesso");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [HttpPost("CreateProvaByConsumer")]
    public async Task<IActionResult> CreateProvaByConsumer([FromBody] ProvaViewModel provaViewModel)
    {
        try
        {
            var prova = new Prova(provaViewModel.AlunoId, provaViewModel.CadernoId);

            prova.SetRespostas(_mapper.Map<List<Resposta>>(provaViewModel.Respostas));

            _provaService.Create(prova);
            return Ok("Prova cadastrada com sucesso");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        
    }
}
