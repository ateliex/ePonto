using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePonto.Features.RegistroPontos;

public interface ConsultaPontosInterface
{
    Task<ConsultaPontosResponse> ConsultarPontos(ConsultaPontosRequest request);
}

public class ConsultaPontosRequest
{

}

public class ConsultaPontosResponse
{
    public Ponto[] Pontos { get; set; }
}

public class Ponto
{
    public DateTime DataHora { get; set; }

    public string? Observacao { get; set; }
}
