namespace Infrastructure.Commands.Insert;

public static class AddClientCommand
{
    public static string Command = """
        INSERT INTO TB_CLIENT 
            ([NAME], [CPF], [PHONE_NUMBER], [EMAIL], [DATE_BIRTH], [ADDRESS], [CEP], [CITY], [DATE_CHANGE], [ID_USER])
        VALUES 
            (@Name, @Cpf, @PhoneNumber, @Email, @DateBirth, @Address, @Cep, @City, @DateChange, @IdUser);
        SELECT 
            CAST(SCOPE_IDENTITY() AS INT) AS [ID_CLIENT];
        """;

    public sealed class AddClientResult
    {
        public int ID_CLIENT { get; set; }
    }
}
