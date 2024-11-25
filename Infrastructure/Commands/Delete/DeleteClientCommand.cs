namespace Infrastructure.Commands.Delete;

public static class DeleteClientCommand
{
    public static string Command =
        """
            DELETE FROM [TB_CLIENT] WHERE [ID_CLIENT] = @IdClient        
        """;
}
