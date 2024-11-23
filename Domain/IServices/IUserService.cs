using Entities.Model;
using Entities.Response;

namespace Domain.IServices;

public interface IUserService
{
    Task<WebResponse<User>> RegisterUser(User user);
    Task<WebResponse<object>> LoginUser(string userEmail, string password);
}
