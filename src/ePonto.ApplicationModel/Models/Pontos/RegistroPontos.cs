namespace ePonto.Models.Pontos;

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
