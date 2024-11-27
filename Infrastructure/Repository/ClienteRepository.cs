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
        DateTime birthDate = Convert.ToDateTime(client.DateBirth);

        var parameters = new
        {
            client.Name,
            client.Cpf,
            client.PhoneNumber,
            client.Email,
            DateBirth = birthDate,
            client.Address,
            client.Cep,
            client.City,
            DateChange = DateTime.Now,
            client.IdUser
        };

        CommandDefinition command = new(
            AddClientCommand.Command,
            parameters: parameters,
            transaction: _context.Transaction
        );

        AddClientResult? result = await _context.Connection.QueryFirstOrDefaultAsync<AddClientResult>(command);

        client.IdClient = result.ID_CLIENT;

        return client;
    }

    public async Task UpdateClient(Client client)
    {
        DateTime birthDate = Convert.ToDateTime(client.DateBirth);
        var parameters = new
        {
            client.Name,
            client.Cpf,
            client.PhoneNumber,
            client.Email,
            DateBirth = birthDate,
            client.Address,
            client.Cep,
            client.City,
            DateChange = DateTime.Now,
            client.IdClient
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
