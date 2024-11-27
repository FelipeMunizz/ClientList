using Entities.Model;

namespace Domain.Interfaces;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetAllClient(int idUser);
    Task<Client> GetClientById(int idClient);
    Task<Client> AddClient(Client client);
    Task UpdateClient(Client client);
    Task DeleteClient(int idClient);
}
