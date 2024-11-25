using Entities.Model;
using Entities.Response;

namespace Domain.IServices;

public interface IClientService
{
    Task<IEnumerable<object>> GetAllClient(int idUser);
    Task<Client> GetClientById(int idClient);
    Task<WebResponse<Client>> AddClient(Client client);
    Task<WebResponse<Client>> UpdateClient(Client client);
    Task<WebResponse<bool>> DeleteClient(int idClient);
}
