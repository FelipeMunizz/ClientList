using Domain.Interfaces;
using Domain.IServices;
using Domain.Services.TokenService;
using Entities.Model;
using Entities.Response;
using FluentValidation;
using FluentValidation.Results;
using Helpers.Utility;
using System.Text;

namespace Domain.Services;

public class UserService : IUserService
{
    private readonly IValidator<User> _validator;
    private readonly IUserRepository _repository;

    public UserService(IValidator<User> validator, IUserRepository repository)
    {
        _validator = validator;
        _repository = repository;
    }

    public async Task<WebResponse<User>> RegisterUser(User user)
    {
        try
        {
            ValidationResult validation = await _validator.ValidateAsync(user);

            if (!validation.IsValid)
            {
                StringBuilder stringBuilder = new StringBuilder();

                foreach(ValidationFailure erros in validation.Errors)
                    stringBuilder.AppendLine(erros.ErrorMessage);

                return new WebResponse<User>
                {
                    Success = false,
                    Message = $"Dados informados inválidos. {stringBuilder.ToString()}",
                    Data = user
                };
            }

            user = await _repository.AddUser(user);

            if (user.ID_USER == 0)
                return new WebResponse<User>
                {
                    Success = false,
                    Message = "Erro ao cadastrar usuário.",
                    Data = user
                };

            return new WebResponse<User>
            {
                Success = true,
                Message = "Usuário cadastrado com sucesso.",
                Data = user
            };
        }
        catch (Exception ex)
        {
            WebResponse<User> response = new WebResponse<User>();
            response.Success = false;
            response.Message = ex.Message;
            response.Data = null;
            response.AddError("500", ex.Message);
            return response;
        }
    }

    public async Task<WebResponse<object>> LoginUser(string userEmail, string password)
    {
        try
        {
            User user = await _repository.LoginUser(userEmail, password);

            if(user == null)
                return new WebResponse<object>
                {
                    Success = false,
                    Message = "Usuário não encontrado.",
                    Data = null
                };

            var  token = new TokenJwtBuilder()
                .AddSecurityKey(JwtSecurityKey.Create(Util.SecurityKey))
                .AddSubject("Client List v1")
                .AddIssuer("ClientList.Security.Bearer")
                .AddAudience("ClientList.Security.Bearer")
                .AddClaim("UsuarioEmail", userEmail)
                .AddExpiry(1440)
                .Builder();

            return new WebResponse<object>
            {
                Success = true,
                Message = "Usuário logado com sucesso",
                Data = new
                {
                    Token = token.value,
                    token.ValidTo
                }
            };
        }
        catch (Exception ex)
        {
            WebResponse<object> response = new WebResponse<object>();
            response.Success = false;
            response.Message = ex.Message;
            response.Data = ex;
            response.AddError("500", ex.Message);
            return response;
        }
    }
}
