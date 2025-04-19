namespace ePonto.Models.Contratos;

public interface BuscaContratosInterface
{
    Task<BuscaContratosResponse> BuscarContratos(BuscaContratosRequest request);
}

public class BuscaContratosRequest
{

}

public class BuscaContratosResponse
{
    public ContratoModel[] Contratos { get; set; }
}

public class ContratoModel
{
    public long Id { get; set; }

    public string? Nome { get; set; }
}
