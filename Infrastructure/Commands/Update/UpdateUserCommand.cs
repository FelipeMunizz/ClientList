namespace Infrastructure.Commands.Update;

public static class UpdateUserCommand
{
    public static string Command =
        """
         UPDATE [TB_USER] SET
            [USER_NAME] = @UserName,
            [USER_EMAIL] = @UserEmail,
            [USER_PASSWORD] = @UserPassword,
            [DATE_CHANGE] = @DateChange,
            [ACTIVE] = @Active,
         WHERE [ID_USER] = @IdUser
        """;
}
