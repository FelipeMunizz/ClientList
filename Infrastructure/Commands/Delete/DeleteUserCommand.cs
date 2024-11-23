namespace Infrastructure.Commands.Delete;

public static class DeleteUserCommand
{
    public static string Command =
        """
            DELETE FROM [TB_USER] WHERE [ID_USER] = @IdUser
        """;
}
