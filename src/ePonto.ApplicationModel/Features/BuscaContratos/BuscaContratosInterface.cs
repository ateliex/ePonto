using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePonto.Features.BuscaContratos;

public interface BuscaContratosInterface
{
    Task<BuscaContratosResponse> BuscarContratos(BuscaContratosRequest request);
}

public class BuscaContratosRequest
{

}

public class BuscaContratosResponse
{
    public Contrato[] Contratos { get; set; }
}

public class Contrato
{
    public long Id { get; set; }

    public string? Nome { get; set; }
}
