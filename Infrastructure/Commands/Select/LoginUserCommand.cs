namespace Infrastructure.Commands.Select;

public static class LoginUserCommand
{
    public static string Command =
        """
         SELECT * FROM [TB_USER] 
         WHERE 
             [USER_EMAIL] = @UserEmail 
             and [USER_PASSWORD] = @UserPassword
             and [ACTIVE] = 1
        """;
}
