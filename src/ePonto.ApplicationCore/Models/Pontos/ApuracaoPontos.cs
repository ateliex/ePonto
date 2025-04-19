using ePonto.Models.Misc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ePonto.Models.Pontos;

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

    public PontoModel[] Pontos { get; set; }

    public ApuracaoDiariaModel()
    {
        TempoPeriodo = new TempoPeriodo();
    }
}

public class PontoModel
{
    [Required(ErrorMessage = "'Contrato' deve ser informado.")]
    [DisplayName("Contrato")]
    public long? ContratoId { get; set; }

    //[DisplayName("Contrato")]
    //public Contrato? Contrato { get; set; }

    [Required]
    [DisplayName("Data/Hora")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime? DataHora { get; set; }

    [Required]
    [DisplayName("Momento")]
    public MomentoEnum? MomentoId { get; set; }

    //[DisplayName("Pausa")]
    //public PausaEnum? PausaId { get; set; }

    //[Required]
    //[DisplayName("Estimado?")]
    //public bool Estimado { get; set; }

    [MinLength(3)]
    [MaxLength(255)]
    [DisplayName("Observação")]
    public string? Observacao { get; set; }

    //public string? UserId { get; set; }

    //[DisplayName("Comprovantes")]
    //public virtual IList<Comprovante> Comprovantes { get; set; } = default!;
}
