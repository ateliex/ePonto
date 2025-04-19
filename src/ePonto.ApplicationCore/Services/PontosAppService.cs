using ePonto.Models.Pontos;
using ePonto.Repositories;

namespace ePonto.Services;

public class PontosAppService :
    RegistroPontosInterface,
    MarcacaoPontosInterface
{
    private readonly PontosRepositoryInterface _pontosRepository;

    public PontosAppService(PontosRepositoryInterface pontosRepository)
    {
        _pontosRepository = pontosRepository;
    }

    public Task<RegistroPontoResponse> RegistrarPonto(RegistroPontoRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<MarcacaoPontoResponse> MarcarPonto(MarcacaoPontoRequest request)
    {
        throw new NotImplementedException();
    }
}
