using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePonto.Features.RegistroPontos;

public interface RegistroPontosInterface
{
    Task<RegistroPontoResponse> RegistrarPonto(RegistroPontoRequest request);
}

public class RegistroPontoRequest
{

}

public class RegistroPontoResponse
{
    public int PontoId { get; set; }
}
