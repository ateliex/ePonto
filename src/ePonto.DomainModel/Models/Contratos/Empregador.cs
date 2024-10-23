using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ePonto.Models.Contratos;

public class Empregador : LocalTableEntity
{
    [Required]
    [MinLength(3)]
    [MaxLength(35)]
    [DisplayName("Nome")]
    public string? Nome { get; set; }

    public string? UserId { get; set; }

    public override string ToString()
    {
        return Nome;
    }
}
