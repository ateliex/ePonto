using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ePonto.Models;

public class MarcacaoPontoFormModel
{
    [DisplayName("Data/Hora")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime? DataHora { get; set; }

    [DisplayName("Observação")]
    public string? Observacao { get; set; }
}
