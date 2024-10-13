using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePonto.Features.MarcacaoPontos;

public interface MarcacaoPontoInterface
{
    Task<MarcacaoPontoResponse> MarcaPonto(MarcacaoPontoRequest request);
}

public class MarcacaoPontoRequest
{

}

public class MarcacaoPontoResponse
{
    public int PontoId { get; set; }
}
