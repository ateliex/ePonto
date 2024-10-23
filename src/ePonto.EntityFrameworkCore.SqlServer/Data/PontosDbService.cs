using ePonto.Features.RegistroPontos;
using ePonto.Models.Pontos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePonto.Data;

public class PontosDbService : PontosRepositoryInterface,
    ConsultaPontosInterface,
    DetalhamentoPontosInterface
{
    public async Task<ConsultaPontosResponse> ConsultarPontos(ConsultaPontosRequest request)
    {
        var response = new ConsultaPontosResponse();

        response.Pontos = [
            new Features.RegistroPontos.Ponto
            {
                DataHora= DateTime.Now
            }
        ];

        return await Task.FromResult(response);
    }

    public Task<DetalhesPontoResponse> DetalharPonto(DetalhesPontoRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Models.Pontos.Ponto[]> ObtemPontos()
    {
        throw new NotImplementedException();
    }
}
