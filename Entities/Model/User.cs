namespace Entities.Model;

/// <summary>
/// Usuário
/// </summary>
public class User
{
    public int ID_USER { get; set; }
    public string? USER_NAME { get; set; }
    public string? USER_EMAIL { get; set; }
    public string? USER_PASSWORD { get; set; }
    public DateTime DATE_CHANGE { get; set; }
    public bool ACTIVE { get; set; }
}

public class LoginUser
{
    public string UserEmail { get; set; }
    public string UserPassword { get; set; }
}
