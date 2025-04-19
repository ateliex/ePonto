namespace ePonto.Models.Pontos;

public interface MarcacaoPontosInterface
{
    Task<MarcacaoPontoResponse> MarcarPonto(MarcacaoPontoRequest request);
}

public class MarcacaoPontoRequest
{

}

public class MarcacaoPontoResponse
{
    public int PontoId { get; set; }
}
