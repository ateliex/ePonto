using ePonto.Models.Contratos;
using ePonto.Models.Contratos;

namespace ePonto.Data;

public class ContratosDbService : ConsultaContratosInterface,
    BuscaContratosInterface
{
    public async Task<BuscaContratosResponse> BuscarContratos(BuscaContratosRequest request)
    {
        var response = new BuscaContratosResponse();

        response.Contratos = [
            new ContratoModel
            {
                Id = 0,
                Nome = "Teste"
            }
        ];

        return await Task.FromResult(response);
    }
}
