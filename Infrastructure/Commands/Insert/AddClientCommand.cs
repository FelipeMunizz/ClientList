namespace Infrastructure.Commands.Insert;

public static class AddClientCommand
{
    public static string Command = """
        INSERT INTO TB_CLIENT 
            (NAME, CPF, PHONE_NUMBER, EMAIL, DATE_BIRTH, ADDRESS, CEP, CITY, DATE_CHANGE)
        VALUES 
            (@Name, @Cpf, @PhoneNumber, @Email, @DateBirth, @Address, @Cep, @City, @DateChange);
        SELECT 
            CAST(SCOPE_IDENTITY() AS INT) AS ID_CLIENT;
        """;
}
