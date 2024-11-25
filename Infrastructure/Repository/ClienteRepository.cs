using Dapper;
using Domain.Interfaces;
using Entities.Model;
using Infrastructure.Commands.Delete;
using Infrastructure.Commands.Insert;
using Infrastructure.Commands.Select;
using Infrastructure.Commands.Update;
using Infrastructure.Context;
using static Infrastructure.Commands.Insert.AddClientCommand;
using static Infrastructure.Commands.Select.GetAllClientCommand;

namespace Infrastructure.Repository;

public class ClienteRepository : IClientRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<object>> GetAllClient(int idUser)
    {
        CommandDefinition command = new(
            GetAllClientCommand.Command,
            parameters: new { IdUser = idUser },
            transaction: _context.Transaction
        );

        return await _context.Connection.QueryAsync<GetAllClientResult>(command);
    }

    public async Task<Client> GetClientById(int idClient)
    {
        CommandDefinition command = new(
            GetClientByIdCommand.Command,
            parameters: new { IdClient = idClient },
            transaction: _context.Transaction
        );

        return await _context.Connection.QueryFirstOrDefaultAsync<Client>(command);
    }

    public async Task<Client> AddClient(Client client)
    {
        var parameters = new
        {
            Name = client.NAME,
            Cpf = client.CPF,
            PhoneNumber = client.PHONE_NUMBER,
            Email = client.EMAIL,
            DateBirth = client.DATE_BIRTH,
            Address = client.ADDRESS,
            Cep = client.CEP,
            City = client.CITY,
            DateChange = DateTime.Now,
            IdUser = client.ID_USER
        };

        CommandDefinition command = new(
            AddClientCommand.Command,
            parameters: parameters,
            transaction: _context.Transaction
        );

        AddClientResult? result = await _context.Connection.QueryFirstOrDefaultAsync<AddClientResult>(command);

        client.ID_CLIENT = result.ID_CLIENT;

        return client;
    }

    public async Task UpdateClient(Client client)
    {
        var parameters = new
        {
            Name = client.NAME,
            Cpf = client.CPF,
            PhoneNumber = client.PHONE_NUMBER,
            Email = client.EMAIL,
            DateBirth = client.DATE_BIRTH,
            Address = client.ADDRESS,
            Cep = client.CEP,
            City = client.CITY,
            DateChange = DateTime.Now,
            IdClient = client.ID_CLIENT
        };

        CommandDefinition command = new(
            UpdateClientCommand.Command,
            parameters: parameters,
            transaction: _context.Transaction
        );

        await _context.Connection.ExecuteAsync(command);
    }

    public async Task DeleteClient(int idClient)
    {
        CommandDefinition command = new(
            DeleteClientCommand.Command,
            parameters: new { IdClient = idClient },
            transaction: _context.Transaction
        );

        await _context.Connection.ExecuteAsync(command);
    }
}
