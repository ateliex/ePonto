using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ePonto.Models.RegistroPontos;

public class IndexViewModel
{
    [BindProperty(SupportsGet = true)]
    public DateTime? DataHora { get; set; }

    [MinLength(3)]
    [MaxLength(255)]
    [BindProperty(SupportsGet = true)]
    public string? Observacao { get; set; }

    public IList<PontoViewModel> Pontos { get; set; } = default!;

    public class PontoViewModel
    {
        [DisplayName("Data/Hora")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime DataHora { get; set; }

        [DisplayName("Observação")]
        public string? Observacao { get; set; }
    }
}
