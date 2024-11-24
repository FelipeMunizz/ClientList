namespace Infrastructure.Commands.Select;

public static class GetUserByIdCommand
{
    public static string Command =
        """
            SELECT * FROM [TB_USER] WHERE [ID_USER] = @IdUser AND and [ACTIVE] = 1
        """;
}
