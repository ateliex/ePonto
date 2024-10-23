using Azure.Core;
using ePonto.Features.RegistroPontos;
using ePonto.Models.Pontos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ePonto.Api;

[Route("api/[controller]")]
[ApiController]
public class RegistroPontosController : ControllerBase
{
    private readonly ConsultaPontosInterface _consultaPontosInterface;
    private readonly DetalhamentoPontosInterface _detalhamentoPontosInterface;
    private readonly MarcacaoPontosInterface _marcacaoPontosInterface;

    public RegistroPontosController(
        ConsultaPontosInterface consultaPontosInterface,
        DetalhamentoPontosInterface detalhamentoPontosInterface,
        MarcacaoPontosInterface marcacaoPontosInterface)
    {
        _consultaPontosInterface = consultaPontosInterface;
        _detalhamentoPontosInterface = detalhamentoPontosInterface;
        _marcacaoPontosInterface = marcacaoPontosInterface;
    }

    [HttpGet("ConsultaPontos")]
    public async Task<ConsultaPontosResponse> GetConsultaPontos([FromQuery] ConsultaPontosRequest request)
    {
        var response = await _consultaPontosInterface.ConsultarPontos(request);

        return response;
    }

    [HttpGet("DetalhesPonto")]
    public async Task<DetalhesPontoResponse> GetDetalhesPonto([FromQuery] DetalhesPontoRequest request)
    {
        var response = await _detalhamentoPontosInterface.DetalharPonto(request);

        return response;
    }

    [HttpPost("MarcacaoPonto")]
    public async Task<MarcacaoPontoResponse> PostMarcacaoPonto(MarcacaoPontoRequest request)
    {
        var response = await _marcacaoPontosInterface.MarcarPonto(request);

        return response;
    }
}
