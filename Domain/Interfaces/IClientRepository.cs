using Entities.Model;

namespace Domain.Interfaces;

public interface IClientRepository
{
    Task<Client> GetAllClient();
    Task<Client> GetClientById(int idClient);
    Task<Client> AddClient(Client user);
    Task UpdateClient(Client user);
    Task DeleteClient(int idClient);
}
