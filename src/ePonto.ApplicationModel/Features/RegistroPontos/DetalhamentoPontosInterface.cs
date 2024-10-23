using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePonto.Features.RegistroPontos;

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
