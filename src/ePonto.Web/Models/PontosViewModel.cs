using ePonto.Features.ConsultaPontos;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ePonto.Models;

public class PontosViewModel
{
    [BindProperty(SupportsGet = true)]
    public DateTime? DataHora { get; set; }

    [MinLength(3)]
    [MaxLength(255)]
    [BindProperty(SupportsGet = true)]
    public string? Observacao { get; set; }

    public IList<Ponto> Pontos { get; set; } = default!;
}
