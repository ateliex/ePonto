using ePonto.Models.Misc;
using System.ComponentModel.DataAnnotations;

namespace ePonto.Models.Pontos;

public interface ApuracaoPontosInterface
{
    Task ApurarPontos();
}

public class ApuracaoMensalModel
{
    public DayOfWeek PrimeiroDiaSemanaMes { get; set; }

    public IList<ApuracaoSemanalModel> Semanas { get; set; } = default!;

    public int TotalSemanas { get => Semanas.Count; }

    public IList<ApuracaoDiariaModel> Dias { get; set; } = default!;

    public int TotalDias { get => Dias.Count; }

    public TimeSpan TempoTotalPrevisto { get; set; }

    public TimeSpan TempoTotalApurado { get; set; }

    public TimeSpan DiferencaTempoTotal { get; set; }

    public TempoPeriodo TempoPeriodo { get; set; }

    public ApuracaoMensalModel()
    {
        Semanas = new List<ApuracaoSemanalModel>();

        Dias = new List<ApuracaoDiariaModel>();

        TempoPeriodo = new TempoPeriodo();
    }
}

public class ApuracaoSemanalModel
{
    public int NumeroSemana { get; set; }

    [DisplayFormat(DataFormatString = "{0:d\\d\\ hh\\:mm}")]
    public TimeSpan TempoTotalPrevisto { get; set; }

    [DisplayFormat(DataFormatString = "{0:d\\d\\ hh\\:mm}")]
    public TimeSpan TempoTotalApurado { get; set; }

    [DisplayFormat(DataFormatString = "{0:d\\d\\ hh\\:mm}")]
    public TimeSpan DiferencaTempoTotal { get; set; }

    public TempoPeriodo TempoPeriodo { get; set; }

    public ApuracaoSemanalModel()
    {
        TempoPeriodo = new TempoPeriodo();
    }
}

public class ApuracaoDiariaModel
{
    public int Dia { get; set; }

    public DayOfWeek DiaSemana { get; set; }

    public string DescricaoDia { get; set; }

    public TimeSpan TempoPrevisto { get; set; }

    public TimeSpan TempoApurado { get; set; }

    public bool TempoApuradoIdeterminado { get; set; }

    public TimeSpan DiferencaTempo { get; set; }

    public TimeSpan TempoAbonado { get; set; }

    public bool Hoje { get; set; }

    public bool Feriado { get; set; }

    public bool Falta { get; set; }

    public string Observacao { get; set; }

    public TempoPeriodo TempoPeriodo { get; set; }

    public DateTime? DataHoraInicio { get; set; }

    public DateTime? DataHoraFim { get; set; }

    public Ponto[] Pontos { get; set; }

    public ApuracaoDiariaModel()
    {
        TempoPeriodo = new TempoPeriodo();
    }
}
