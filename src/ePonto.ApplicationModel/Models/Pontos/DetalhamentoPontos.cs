namespace ePonto.Models.Pontos;

public interface DetalhamentoPontosInterface
{
    Task<DetalhesPontoResponse> DetalharPonto(DetalhesPontoRequest request);
}

public class DetalhesPontoRequest
{

}

public class DetalhesPontoResponse
{
    public DetalhesPonto DetalhesPonto { get; set; }
}

public class DetalhesPonto
{
    public DateTime DataHora { get; set; }

    public string? Observacao { get; set; }
}
