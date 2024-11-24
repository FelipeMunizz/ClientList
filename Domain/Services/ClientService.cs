using Domain.Interfaces;
using Domain.IServices;
using Entities.Model;
using Entities.Response;
using FluentValidation;
using FluentValidation.Results;

namespace Domain.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _repository;
    private readonly IValidator<Client> _validator;

    public ClientService(IClientRepository repository, IValidator<Client> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public Task<IEnumerable<object>> GetAllClient(int idUser) => _repository.GetAllClient(idUser);

    public async Task<Client> GetClientById(int idClient) => await _repository.GetClientById(idClient);

    public async Task<WebResponse<Client>> AddClient(Client client)
    {
        ValidationResult validation = _validator.Validate(client);
        if(!validation.IsValid)
            return new WebResponse<Client>
            {
                Success = false,
                Message = "Dados informados inválidos.",
                Data = client
            };

        client = await _repository.AddClient(client);

        return new WebResponse<Client>
        {
            Success = true,
            Message = "Cliente inserido com sucesso",
            Data= client
        };
    }

    public Task UpdateClient(Client client)
    {
        throw new NotImplementedException();
    }

    public Task DeleteClient(int idClient)
    {
        throw new NotImplementedException();
    }
}
