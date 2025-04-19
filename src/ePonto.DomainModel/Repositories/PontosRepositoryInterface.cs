using ePonto.Models.Pontos;

namespace ePonto.Repositories;

public interface PontosRepositoryInterface
{
    Task<Ponto[]> ObtemPontos();
}
