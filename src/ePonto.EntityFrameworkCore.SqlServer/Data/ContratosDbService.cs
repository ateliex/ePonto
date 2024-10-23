using ePonto.Features.BuscaContratos;
using ePonto.Features.GestaoContratos;
using ePonto.Features.RegistroPontos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePonto.Data;

public class ContratosDbService : ConsultaContratosInterface,
    BuscaContratosInterface
{
    public async Task<BuscaContratosResponse> BuscarContratos(BuscaContratosRequest request)
    {
        var response = new BuscaContratosResponse();

        response.Contratos = [
            new Features.BuscaContratos.Contrato
            {
                Id = 0,
                Nome = "Teste"
            }
        ];

        return await Task.FromResult(response);
    }
}
