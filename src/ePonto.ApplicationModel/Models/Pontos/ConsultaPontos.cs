namespace ePonto.Models.Pontos;

public interface ConsultaPontosInterface
{
    Task<ConsultaPontosResponse> ConsultarPontos(ConsultaPontosRequest request);
}

public class ConsultaPontosRequest
{

}

public class ConsultaPontosResponse
{
    public PontoModel[] Pontos { get; set; }
}

public class PontoModel
{
    public DateTime DataHora { get; set; }

    public string? Observacao { get; set; }
}
