using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Model;

public class Client
{
    [JsonPropertyName("ID_CLIENT")]
    public int ID_CLIENT { get; set; }

    [JsonPropertyName("NAME")]
    public string? NAME { get; set; }

    [JsonPropertyName("CPF")]
    public string? CPF { get; set; }

    [JsonPropertyName("PHONE_NUMBER")]
    public string? PHONE_NUMBER { get; set; }

    [JsonPropertyName("EMAIL")]
    public string? EMAIL { get; set; }

    [JsonPropertyName("DATE_BIRTH")]
    public DateTime DATE_BIRTH { get; set; }

    [JsonPropertyName("ADDRESS")]
    public string? ADDRESS { get; set; }

    [JsonPropertyName("CEP")]
    public string? CEP { get; set; }

    [JsonPropertyName("CITY")]
    public string? CITY { get; set; }

    [JsonPropertyName("DATE_CHANGE")]
    public DateTime DATE_CHANGE { get; set; }

    [JsonPropertyName("ID_USER")]
    [ForeignKey("USER")]
    public int ID_USER { get; set; }
    [JsonIgnore]
    public virtual User? USER { get; set; }
}
