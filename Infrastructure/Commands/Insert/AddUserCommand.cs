namespace Infrastructure.Commands.Insert;

public static class AddUserCommand
{
    public static string Command = 
        """
        INSERT INTO [TB_USER] 
            ([USER_NAME], [USER_PASSWORD], [USER_EMAIL], [DATE_CHANGE], [ACTIVE])
        VALUES 
            (@UserName, @UserPassword, @UserEmail, @DateChange, @Active);
        SELECT 
            CAST(SCOPE_IDENTITY() AS INT) AS ID_USER;
        """;

    public sealed class AddUserResult
    {
        public int ID_USER { get; set; }
    }
}
