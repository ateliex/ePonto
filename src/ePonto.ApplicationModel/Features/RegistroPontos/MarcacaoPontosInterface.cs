using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePonto.Features.RegistroPontos;

public interface MarcacaoPontosInterface
{
    Task<MarcacaoPontoResponse> MarcarPonto(MarcacaoPontoRequest request);
}

public class MarcacaoPontoRequest
{

}

public class MarcacaoPontoResponse
{
    public int PontoId { get; set; }
}
