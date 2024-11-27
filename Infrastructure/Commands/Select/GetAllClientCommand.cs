namespace Infrastructure.Commands.Select;

public static class GetAllClientCommand
{
    public static string Command =
        """
         SELECT 
             [CLIENT].[ID_CLIENT] as [IdClient],
             [CLIENT].[NAME] as [Name],
             [CLIENT].[CPF] as [Cpf],
             [CLIENT].[EMAIL] as [Email],
             [CLIENT].[PHONE_NUMBER] as [PhoneNumber],
             FORMAT([CLIENT].[DATE_BIRTH], 'dd/MM/yyyy') AS [DateBirth],
             [CLIENT].[ADDRESS] as [Address],
             [CLIENT].[CEP] as [Cep],
             [CLIENT].[CITY] as [City],
             [USER].[ID_USER] as [IdUser]
         FROM [TB_CLIENT] AS [CLIENT]
         JOIN [TB_USER] AS [USER] ON [CLIENT].[ID_USER] = [USER].[ID_USER]
         WHERE 
             [CLIENT].[ID_USER] = @IdUser
        """;
}
