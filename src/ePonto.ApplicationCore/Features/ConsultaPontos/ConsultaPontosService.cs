using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePonto.Features.ConsultaPontos;

public class ConsultaPontosService : ConsultaPontosInterface
{
    public async Task<ConsultaPontosResponse> ConsultaPontos(ConsultaPontosRequest request)
    {
        var response = new ConsultaPontosResponse();

        response.Pontos = new Ponto[] {
            new Ponto
            {
                DataHora= DateTime.Now
            }
        };

        return await Task.FromResult(response);
    }
}
