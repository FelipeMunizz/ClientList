using Dapper;
using Domain.Interfaces;
using Entities.Model;
using Helpers.Cryptography;
using Infrastructure.Commands.Delete;
using Infrastructure.Commands.Insert;
using Infrastructure.Commands.Select;
using Infrastructure.Commands.Update;
using Infrastructure.Context;
using static Infrastructure.Commands.Insert.AddUserCommand;

namespace Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> AddUser(User user)
    {
        user.USER_PASSWORD = CryptographyPassword(user.USER_PASSWORD);

        var parameters = new
        {
            UserName = user.USER_NAME,
            UserPassword = user.USER_PASSWORD,
            UserEmail = user.USER_EMAIL,
            DateChange = DateTime.Now,
            Active = true
        };

        CommandDefinition command = new(
            AddUserCommand.Command,
            parameters: parameters,
            transaction: _context.Transaction
         );

        AddUserResult result = await _context.Connection.QueryFirstOrDefaultAsync<AddUserResult>(command);

        user.ID_USER = result.ID_USER;

        return user;
    }

    public async Task UpdateUser(User user)
    {
        user.USER_PASSWORD = CryptographyPassword(user.USER_PASSWORD);

        var parameters = new
        {
            IdUser = user.ID_USER,
            UserName = user.USER_NAME,
            UserPassword = user.USER_PASSWORD,
            UserEmail = user.USER_EMAIL,
            DateChange = DateTime.Now,
            Active = user.ACTIVE
        };

        CommandDefinition command = new(
            UpdateUserCommand.Command,
            parameters: parameters,
            transaction: _context.Transaction
        );

        await _context.Connection.ExecuteAsync(command);
    }

    public async Task DeleteUser(int idUser)
    {
        var parameters = new
        {
            IdUser = idUser
        };

        CommandDefinition command = new(
            DeleteUserCommand.Command,
            parameters: parameters,
            transaction: _context.Transaction
         );

        await _context.Connection.ExecuteAsync(command);
    }

    public async Task<User> GetUserById(int idUser)
    {
        var parameters = new
        {
            IdUser = idUser
        };

        CommandDefinition command = new(
            GetUserByIdCommand.Command,
            parameters: parameters,
            transaction: _context.Transaction
         );

        return await _context.Connection.QueryFirstOrDefaultAsync<User>(command);
    }

    public async Task<User> LoginUser(string userEmail, string password)
    {
        password = CryptographyPassword(password);

        var parameters = new
        {
            UserEmail = userEmail,
            UserPassword = password
        };

        CommandDefinition command = new(
            LoginUserCommand.Command,
            parameters: parameters,
            transaction: _context.Transaction
        );

        return await _context.Connection.QueryFirstOrDefaultAsync<User>(command);
    }

    private string CryptographyPassword(string password)
    {
        CryptographyHelper cryptographyHelper = new CryptographyHelper();

        return cryptographyHelper.Encrypt(password);
    }
}
