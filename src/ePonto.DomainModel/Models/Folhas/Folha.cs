using ePonto.Helpers;
using ePonto.Models.Contratos;
using ePonto.Models.Pontos;
using ePonto.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ePonto.Models.Folhas;

public class Folha : LocalTableEntity
{
    [Required]
    [DisplayName("Contrato")]
    public long? ContratoId { get; set; }

    [DisplayName("Contrato")]
    public Contrato? Contrato { get; set; }

    [Required]
    [DisplayName("Competência")]
    [DisplayFormat(DataFormatString = "{0:y}")]
    public DateTime? Competencia { get; set; }

    [Required]
    [DisplayName("Status")]
    public StatusFolhaEnum? StatusId { get; set; }

    [MinLength(3)]
    [MaxLength(255)]
    [DisplayName("Observação")]
    public string? Observacao { get; set; }

    [DisplayName("Apuração Mensal")]
    public ApuracaoMensal ApuracaoMensal { get; set; }

    public string? UserId { get; set; }

    public Folha()
    {
        ApuracaoMensal = new ApuracaoMensal();
    }

    public void AssociarAo(Contrato contrato)
    {
        Contrato = contrato;
        ContratoId = contrato.Id;
    }

    public void ConfirmarCompetencia(Contrato? contrato)
    {
        var competenciaAtual = Competencia.Value;

        var competenciaPosterior = competenciaAtual.AddMonths(1);

        var dias = (competenciaPosterior - competenciaAtual).Days;

        if (ApuracaoMensal.Dias.Count == 0)
        {
            for (int dia = 1; dia <= dias; dia++)
            {
                var data = competenciaAtual.AddDays(dia - 1);

                var apuracaoDiaria = new ApuracaoDiaria
                {
                    Dia = dia,
                    TempoPrevisto = contrato.JornadaTrabalhoSemanalPrevista.Semana.Single(x => x.DiaSemana == data.DayOfWeek).Tempo,
                    TempoApurado = null,
                    DiferencaTempo = null,
                    Feriado = false,
                    Falta = false
                };

                ApuracaoMensal.Dias.Add(apuracaoDiaria);
            }

            ApuracaoMensal.TempoTotalPeriodoAnterior = TimeSpan.Zero;
        }
        else
        {
            for (int dia = 1; dia <= dias; dia++)
            {
                var data = competenciaAtual.AddDays(dia - 1);

                if (ApuracaoMensal.Dias.Any(x => x.Dia == dia))
                {
                    var apuracaoDiaria = ApuracaoMensal.Dias.First(x => x.Dia == dia);

                    apuracaoDiaria.TempoPrevisto = contrato.JornadaTrabalhoSemanalPrevista.Semana.Single(x => x.DiaSemana == data.DayOfWeek).Tempo;
                    apuracaoDiaria.TempoApurado = null;
                    apuracaoDiaria.DiferencaTempo = null;
                    apuracaoDiaria.DiferencaTempo = null;
                    apuracaoDiaria.Feriado = false;
                }
                else
                {
                    var apuracaoDiaria = new ApuracaoDiaria
                    {
                        Dia = dia,
                        TempoPrevisto = contrato.JornadaTrabalhoSemanalPrevista.Semana.Single(x => x.DiaSemana == data.DayOfWeek).Tempo,
                        TempoApurado = null,
                        DiferencaTempo = null,
                        Feriado = false,
                        Falta = false,
                        Observacao = null
                    };

                    ApuracaoMensal.Dias.Add(apuracaoDiaria);
                }
            }

            ApuracaoMensal.TempoTotalPeriodoAnterior = TimeSpan.Zero;
        }
    }

    public void Marcar(Ponto ponto)
    {
        if (Contrato.Ativo == false)
        {
            throw new ApplicationException("Contrato inativo.");
        }
    }

    //public async Task<ApuracaoMensal> ApurarPontos(PontosRepositoryInterface pontosRepository, ClaimsPrincipal user, DateTime hoje, DateTime competenciaAtual, DateTime competenciaFolha, DateTime competenciaFolhaPosterior)
    //{
    //    var apuracaoMensal = new ApuracaoMensal();

    //    var pontos = await pontosRepository.ObtemPontos();

    //    //var pontos = await db.Pontos
    //    //    .Where(x => true
    //    //        && x.DataHora >= competenciaFolha
    //    //        && x.DataHora < competenciaFolhaPosterior
    //    //        && x.UserId == user.GetUserId())
    //    //    .OrderByDescending(x => x.DataHora)
    //    //    .ToListAsync();

    //    //apuracaoMensal.PrimeiroDiaSemanaMes = competenciaFolha.DayOfWeek;

    //    var primeiroDiaSemanaMes = competenciaFolha.DayOfWeek;

    //    var totalInteiroSemanas = (int)(competenciaFolhaPosterior - competenciaFolha).TotalDays / 7;

    //    var restoDiasSemana = (competenciaFolhaPosterior - competenciaFolha).TotalDays % 7;

    //    int totalSemanas = totalInteiroSemanas + 2;

    //    apuracaoMensal.TempoTotalPrevisto = TimeSpan.Zero;

    //    apuracaoMensal.TempoTotalApurado = TimeSpan.Zero;

    //    apuracaoMensal.DiferencaTempoTotal = TimeSpan.Zero;

    //    if (competenciaFolha < competenciaAtual)
    //    {
    //        apuracaoMensal.TempoPeriodo.Atual = false;
    //        apuracaoMensal.TempoPeriodo.Passado = true;
    //        apuracaoMensal.TempoPeriodo.Futuro = false;
    //    }
    //    else if (competenciaFolha == competenciaAtual)
    //    {
    //        apuracaoMensal.TempoPeriodo.Atual = true;
    //        apuracaoMensal.TempoPeriodo.Passado = false;
    //        apuracaoMensal.TempoPeriodo.Futuro = false;
    //    }
    //    else
    //    {
    //        apuracaoMensal.TempoPeriodo.Atual = false;
    //        apuracaoMensal.TempoPeriodo.Passado = false;
    //        apuracaoMensal.TempoPeriodo.Futuro = true;
    //    }

    //    int diaIndex = -1;

    //    for (int semanaIndex = 0; semanaIndex < totalSemanas; semanaIndex++)
    //    {
    //        var numeroSemanaAtual = hoje.GetWeekNumber();

    //        var apuracaoSemanalModel = new ApuracaoSemanal
    //        {
    //            NumeroSemana = competenciaFolha.GetWeekNumber() + semanaIndex,
    //            TempoTotalPrevisto = TimeSpan.Zero,
    //            TempoTotalApurado = TimeSpan.Zero,
    //            DiferencaTempoTotal = TimeSpan.Zero,
    //        };

    //        if (apuracaoMensal.TempoPeriodo.Passado)
    //        {
    //            apuracaoSemanalModel.TempoPeriodo.Atual = false;
    //            apuracaoSemanalModel.TempoPeriodo.Passado = true;
    //            apuracaoSemanalModel.TempoPeriodo.Futuro = false;
    //        }
    //        else if (apuracaoMensal.TempoPeriodo.Atual)
    //        {
    //            if (apuracaoSemanalModel.NumeroSemana < numeroSemanaAtual)
    //            {
    //                apuracaoSemanalModel.TempoPeriodo.Atual = false;
    //                apuracaoSemanalModel.TempoPeriodo.Passado = true;
    //                apuracaoSemanalModel.TempoPeriodo.Futuro = false;
    //            }
    //            else if (apuracaoSemanalModel.NumeroSemana == numeroSemanaAtual)
    //            {
    //                apuracaoSemanalModel.TempoPeriodo.Atual = true;
    //                apuracaoSemanalModel.TempoPeriodo.Passado = false;
    //                apuracaoSemanalModel.TempoPeriodo.Futuro = false;
    //            }
    //            else
    //            {
    //                apuracaoSemanalModel.TempoPeriodo.Atual = false;
    //                apuracaoSemanalModel.TempoPeriodo.Passado = false;
    //                apuracaoSemanalModel.TempoPeriodo.Futuro = true;
    //            }
    //        }
    //        else
    //        {
    //            apuracaoSemanalModel.TempoPeriodo.Atual = false;
    //            apuracaoSemanalModel.TempoPeriodo.Passado = false;
    //            apuracaoSemanalModel.TempoPeriodo.Futuro = true;
    //        }

    //        int ultimoDiaSemanaIndex;

    //        if (semanaIndex == 0)
    //        {
    //            ultimoDiaSemanaIndex = 7 - (int)primeiroDiaSemanaMes;
    //        }
    //        else
    //        {
    //            ultimoDiaSemanaIndex = 7;
    //        }

    //        for (int diaSemanaIndex = 0; diaSemanaIndex < ultimoDiaSemanaIndex; diaSemanaIndex++)
    //        {
    //            diaIndex++;

    //            if (diaIndex >= ApuracaoMensal.TotalDias)
    //            {
    //                break;
    //            }

    //            //

    //            var apuracaoDiaria = ApuracaoMensal.Dias[diaIndex];

    //            DateTime? horaEntrada = null;

    //            bool? tempoApuradoIndeterminado = null;

    //            TimeSpan? tempoApurado = TimeSpan.Zero;

    //            var pontosDoDia = pontos
    //                .Where(x => x.DataHora.Value.Day == apuracaoDiaria.Dia.Value)
    //                .OrderBy(x => x.DataHora);

    //            foreach (var pontoDoDia in pontosDoDia)
    //            {
    //                if (horaEntrada == null)
    //                {
    //                    if (pontoDoDia.MomentoId == MomentoEnum.Entrada)
    //                    {
    //                        horaEntrada = pontoDoDia.DataHora;
    //                    }
    //                    else
    //                    {
    //                        tempoApuradoIndeterminado = true;

    //                        break;
    //                    }
    //                }
    //                else
    //                {
    //                    if (pontoDoDia.MomentoId == MomentoEnum.Saida)
    //                    {
    //                        var tempoRealizado = pontoDoDia.DataHora - horaEntrada;

    //                        if (tempoApurado == null)
    //                        {
    //                            tempoApurado = tempoRealizado;
    //                        }
    //                        else
    //                        {
    //                            tempoApurado += tempoRealizado;
    //                        }

    //                        horaEntrada = null;
    //                    }
    //                    else
    //                    {
    //                        tempoApuradoIndeterminado = true;

    //                        break;
    //                    }
    //                }
    //            }

    //            var diferencaTempo = tempoApurado - (apuracaoDiaria.TempoPrevisto ?? TimeSpan.Zero);

    //            var data = competenciaFolha.AddDays(apuracaoDiaria.Dia.Value - 1);

    //            var apuracaoDiariaModel = new ApuracaoDiaria
    //            {
    //                Dia = apuracaoDiaria.Dia.Value,
    //                //DiaSemana = data.DayOfWeek,
    //                //DescricaoDia = data.DayOfWeek.Translate(),
    //                TempoPrevisto = apuracaoDiaria.TempoPrevisto ?? TimeSpan.Zero,
    //                TempoApurado = tempoApurado ?? TimeSpan.Zero,
    //                TempoApuradoIdeterminado = tempoApuradoIndeterminado ?? false,
    //                DiferencaTempo = diferencaTempo ?? TimeSpan.Zero,
    //                TempoAbonado = apuracaoDiaria.TempoAbonado ?? TimeSpan.Zero,
    //                //Hoje = data == hoje,
    //                Feriado = apuracaoDiaria.Feriado,
    //                Falta = apuracaoDiaria.Falta,
    //                Observacao = apuracaoDiaria.Observacao,
    //                DataHoraInicio = pontosDoDia.FirstOrDefault()?.DataHora,
    //                DataHoraFim = pontosDoDia.LastOrDefault()?.DataHora,
    //                //Pontos = pontosDoDia.ToArray()
    //            };

    //            apuracaoDiaria.TempoApurado = apuracaoDiaria.TempoApurado ?? TimeSpan.Zero;

    //            apuracaoDiaria.DiferencaTempo = apuracaoDiaria.DiferencaTempo ?? TimeSpan.Zero;

    //            //

    //            apuracaoSemanalModel.TempoTotalPrevisto += apuracaoDiariaModel.TempoPrevisto;

    //            apuracaoSemanalModel.TempoTotalApurado += apuracaoDiariaModel.TempoApurado + apuracaoDiariaModel.TempoAbonado;

    //            apuracaoSemanalModel.DiferencaTempoTotal += apuracaoDiariaModel.DiferencaTempo + apuracaoDiariaModel.TempoAbonado;

    //            if (apuracaoDiaria.TempoPrevisto != TimeSpan.Zero)
    //            {
    //            }

    //            //

    //            apuracaoMensal.Dias.Add(apuracaoDiariaModel);

    //            //


    //            if (data < hoje)
    //            {
    //                apuracaoDiariaModel.TempoPeriodo.Atual = false;
    //                apuracaoDiariaModel.TempoPeriodo.Passado = true;
    //                apuracaoDiariaModel.TempoPeriodo.Futuro = false;
    //            }
    //            else if (data == hoje)
    //            {
    //                apuracaoDiariaModel.TempoPeriodo.Atual = true;
    //                apuracaoDiariaModel.TempoPeriodo.Passado = false;
    //                apuracaoDiariaModel.TempoPeriodo.Futuro = false;
    //            }
    //            else
    //            {
    //                apuracaoDiariaModel.TempoPeriodo.Atual = false;
    //                apuracaoDiariaModel.TempoPeriodo.Passado = false;
    //                apuracaoDiariaModel.TempoPeriodo.Futuro = true;
    //            }
    //        }

    //        apuracaoMensal.TempoTotalPrevisto += apuracaoSemanalModel.TempoTotalPrevisto;

    //        apuracaoMensal.TempoTotalApurado += apuracaoSemanalModel.TempoTotalApurado;

    //        apuracaoMensal.DiferencaTempoTotal += apuracaoSemanalModel.DiferencaTempoTotal;

    //        apuracaoMensal.Semanas.Add(apuracaoSemanalModel);
    //    }

    //    return apuracaoMensal;
    //}
}

//[Owned]
public class ApuracaoMensal
{
    [DisplayName("Dias")]
    public IList<ApuracaoDiaria> Dias { get; set; }

    [DisplayName("Total Dias")]
    public int TotalDias { get => Dias.Count; }

    [DisplayName("Tempo Total Previsto")]
    //[DisplayFormat(DataFormatString = "{0:d\\d\\ hh\\:mm}")]
    public TimeSpan? TempoTotalPrevisto
    {
        get
        {
            TimeSpan? total = null;

            foreach (var apuracaoDiaria in Dias)
            {
                if (apuracaoDiaria.TempoPrevisto.HasValue)
                {
                    total = (total ?? TimeSpan.Zero) + apuracaoDiaria.TempoPrevisto;
                }
            }

            return total;
        }
    }

    [DisplayName("Tempo Total Apurado")]
    //[DisplayFormat(DataFormatString = "{0:d\\d\\ hh\\:mm}")]
    public TimeSpan? TempoTotalApurado
    {
        get
        {
            TimeSpan? total = null;

            foreach (var apuracaoDiaria in Dias)
            {
                if (apuracaoDiaria.TempoApurado.HasValue)
                {
                    total = (total ?? TimeSpan.Zero) + apuracaoDiaria.TempoApurado + (apuracaoDiaria.TempoAbonado ?? TimeSpan.Zero);
                }
            }

            return total;
        }
    }

    [DisplayName("Diferença Tempo Total")]
    //[DisplayFormat(DataFormatString = "{0:d\\d\\ hh\\:mm}")]
    public TimeSpan? DiferencaTempoTotal
    {
        get
        {
            TimeSpan? total = null;

            foreach (var apuracaoDiaria in Dias)
            {
                if (apuracaoDiaria.DiferencaTempo.HasValue)
                {
                    total = (total ?? TimeSpan.Zero) + apuracaoDiaria.DiferencaTempo;
                }
            }

            return total;
        }
    }

    //public TempoPeriodo TempoPeriodo { get; set; }

    [DisplayName("Tempo Total Período Anterior")]
    //[DisplayFormat(DataFormatString = "{0:d\\d\\ hh\\:mm}")]
    public TimeSpan? TempoTotalPeriodoAnterior { get; set; }

    public ApuracaoMensal()
    {
        Dias = new List<ApuracaoDiaria>();
    }
}

//[Owned]
public class ApuracaoDiaria
{
    [Required]
    [DisplayName("Dia")]
    public int? Dia { get; set; }

    [Required]
    [DisplayName("Tempo Previsto")]
    [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
    public TimeSpan? TempoPrevisto { get; set; }

    [DisplayName("Tempo Apurado")]
    [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
    public TimeSpan? TempoApurado { get; set; }

    //public bool TempoApuradoIdeterminado { get; set; }

    [DisplayName("Diferença Tempo")]
    [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
    public TimeSpan? DiferencaTempo { get; set; }

    [DisplayName("Tempo Abonado")]
    [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
    public TimeSpan? TempoAbonado { get; set; }

    [Required]
    [DisplayName("Feriado?")]
    public bool Feriado { get; set; }

    [Required]
    [DisplayName("Falta?")]
    public bool Falta { get; set; }

    [MinLength(3)]
    [MaxLength(255)]
    [DisplayName("Observação")]
    public string? Observacao { get; set; }
}
