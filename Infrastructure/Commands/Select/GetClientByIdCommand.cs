namespace Infrastructure.Commands.Select;

public static class GetClientByIdCommand
{
    public static string Command =
        """
            SELECT * FROM [TB_CLIENT] WHERE [ID_CLIENT] = @IdClient
        """;
}
