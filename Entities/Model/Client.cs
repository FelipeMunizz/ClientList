using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Model;

public class Client
{
    public int ID_CLIENT { get; set; }
    public string? NAME { get; set; }
    public string? CPF { get; set; }
    public string? PHONE_NUMBER { get; set; }
    public string? EMAIL { get; set; }
    public DateTime DATE_BIRTH { get; set; }
    public string? ADDRESS { get; set; }
    public string? CEP { get; set; }
    public string? CITY { get; set; }
    public DateTime DATE_CHANGE { get; set; }

    [ForeignKey("USER")]
    public int ID_USER { get; set; }
    [JsonIgnore]
    public virtual User? USER { get; set; }
}
