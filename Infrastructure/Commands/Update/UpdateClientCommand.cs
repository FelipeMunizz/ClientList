namespace Infrastructure.Commands.Update;

public static class UpdateClientCommand
{
    public static string Command =
        """
         UPDATE [TB_CLIENT] SET
             [NAME] = @Name,
             [CPF] = @Cpf,
             [EMAIL] = @Email,
             [PHONE_NUMBER] = @PhoneNumber,
             [DATE_BIRTH] = @DateBirth,
             [ADDRESS] = @Address,
             [CEP] = @Cep,
             [CITY] = @City
         WHERE [ID_CLIENT] = @IdClient
        """;
}
