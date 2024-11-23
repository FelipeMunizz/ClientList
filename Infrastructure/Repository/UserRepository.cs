using Dapper;
using Domain.Interfaces;
using Entities.Model;
using FluentValidation;
using FluentValidation.Results;
using Helpers.Cryptography;
using Infrastructure.Commands.Insert;
using Infrastructure.Context;
using System;
using static Infrastructure.Commands.Insert.AddUserCommand;

namespace Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private IValidator<User> _validatorUser;
    private AppDbContext _context;

    public UserRepository(IValidator<User> validatorUser, AppDbContext context)
    {
        _validatorUser = validatorUser;
        _context = context;
    }

    public async Task<User> AddUser(User user)
    {
        ValidationResult validationResult = await _validatorUser.ValidateAsync(user);

        if (!validationResult.IsValid)
            throw new Exception("Usuário com informações invalidas!");

        CryptographyHelper cryptographyHelper = new CryptographyHelper();

        user.USER_PASSWORD = cryptographyHelper.Encrypt(user.USER_PASSWORD);

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

        AddUserResult result = await _context.Connection.QueryFirstAsync(command);

        user.ID_USER = result.ID_USER;

        return user;
    }

    public Task DeleteUser(int idUser)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserById(int idUser)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUser(User user)
    {
        throw new NotImplementedException();
    }
}
