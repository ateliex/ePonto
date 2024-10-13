using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePonto.Features.ConsultaPontos;

public interface ConsultaPontosInterface
{
    Task<ConsultaPontosResponse> ConsultaPontos(ConsultaPontosRequest request);
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
    [DisplayName("Data/Hora")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime DataHora { get; set; }

    [DisplayName("Observação")]
    public string? Observacao { get; set; }
}
