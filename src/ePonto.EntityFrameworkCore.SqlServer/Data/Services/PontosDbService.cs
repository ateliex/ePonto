using ePonto.Models.Pontos;
using ePonto.Repositories;

namespace ePonto.Data.Services;

public class PontosDbService : PontosRepositoryInterface
{
    //public async Task<ConsultaPontosResponse> ConsultarPontos(ConsultaPontosRequest request)
    //{
    //    var response = new ConsultaPontosResponse();

    //    response.Pontos = [
    //        new PontoModel
    //        {
    //            DataHora= DateTime.Now
    //        }
    //    ];

    //    return await Task.FromResult(response);
    //}

    //public Task<DetalhesPontoResponse> DetalharPonto(DetalhesPontoRequest request)
    //{
    //    throw new NotImplementedException();
    //}

    public Task<Ponto[]> ObtemPontos()
    {
        throw new NotImplementedException();
    }
}
