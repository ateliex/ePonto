using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ePonto.Models;

public class MarcacaoPontoViewModel
{
    [BindProperty]
    public MarcacaoPontoFormModel Ponto { get; set; }
}
