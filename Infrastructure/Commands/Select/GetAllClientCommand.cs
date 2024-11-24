namespace Infrastructure.Commands.Select;

public static class GetAllClientCommand
{
    public static string Command =
        """
         SELECT 
             [CLIENT].[ID_CLIENT],
             [CLIENT].[NAME],
             [CLIENT].[CPF],
             [CLIENT].[EMAIL],
             [CLIENT].[PHONE_NUMBER],
             [CLIENT].[DATE_BIRTH],
             [CLIENT].[ADDRESS],
             [CLIENT].[CEP],
             [CLIENT].[CITY],
             [USER].[ID_USER],
             [USER].[USER_NAME]
         FROM [TB_CLIENT] AS [CLIENT]
         JOIN [TB_USER] AS [USER] ON [CLIENT].[ID_USER] = [USER].[ID_USER]
         WHERE 
             [CLIENT].[ID_USER] = @IdUser
        """;
    public sealed class GetAllClientResult
    {
        public int ID_CLIENT { get; set; }
        public string? NAME { get; set; }
        public string? CPF { get; set; }
        public string? EMAIL { get; set; }
        public string? PHONE_NUMBER { get; set; }
        public DateTime DATE_BIRTH { get; set; }
        public string? ADDRESS { get; set; }
        public string? CEP { get; set; }
        public string? CITY { get; set; }
        public int ID_USER { get; set; }
        public string? USER_NAME { get; set; }
    }
}
