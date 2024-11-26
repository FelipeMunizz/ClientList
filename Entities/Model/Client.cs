using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Model;

public class Client
{
    public int IdClient { get; set; }

    public string? Name { get; set; }

    public string? Cpf { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public DateTime DateBirth { get; set; }

    public string? Address { get; set; }

    public string? Cep { get; set; }

    public string? City { get; set; }

    public DateTime DateChange { get; set; }

    [ForeignKey("USER")]
    public int IdUser { get; set; }
    [JsonIgnore]
    public virtual User? USER { get; set; }
}
