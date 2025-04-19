using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ePonto.Models.RegistroPontos;

public class RegistrarViewModel
{
    [DisplayName("Data/Hora")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime? DataHora { get; set; }

    [BindProperty]
    public PontoViewModel Ponto { get; set; }

    public class PontoViewModel
    {
        [DisplayName("Observação")]
        public string? Observacao { get; set; }
    }
}
