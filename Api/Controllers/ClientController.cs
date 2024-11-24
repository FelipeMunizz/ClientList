using Domain.IServices;
using Entities.Model;
using Entities.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpGet("GetAllClient/{idUser:int}")]
        [Produces("application/json")]
        public async Task<IEnumerable<object>> GetAllClient(int idUser) 
            => await _service.GetAllClient(idUser);

        [HttpGet("GetClientById/{idClient:int}")]
        [Produces("application/json")]
        public async Task<ActionResult<Client>> GetClientById(int idClient)
            => await _service.GetClientById(idClient);

        [HttpPost("AddClient")]
        [Produces("application/json")]
        public async Task<ActionResult<WebResponse<Client>>> AddClient(Client client) 
            => await _service.AddClient(client);
    }
}
