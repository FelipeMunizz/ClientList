using Entities.Model;

namespace Domain.Interfaces;

public interface IUserRepository
{
    Task<User> GetUserById(int idUser);
    Task<User> LoginUser(string userEmail, string password);
    Task<User> AddUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(int idUser);
}
