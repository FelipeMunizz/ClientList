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

        [HttpGet("GetAllClient")]
        [Produces("application/json")]
        public async Task<IEnumerable<object>> GetAllClient([FromQuery] int idUser)
            => await _service.GetAllClient(idUser);

        [HttpGet("GetClientById")]
        [Produces("application/json")]
        public async Task<ActionResult<Client>> GetClientById([FromQuery] int idClient)
            => await _service.GetClientById(idClient);

        [HttpPost("AddClient")]
        [Produces("application/json")]
        public async Task<ActionResult<WebResponse<Client>>> AddClient(Client client)
            => await _service.AddClient(client);

        [HttpPut("UpdateClient")]
        [Produces("application/json")]
        public async Task<ActionResult<WebResponse<Client>>> UpdateClient(Client client)
            => await _service.UpdateClient(client);

        [HttpDelete("DeleteClient")]
        [Produces("application/json")]
        public async Task<ActionResult<WebResponse<bool>>> DeleteClient([FromQuery] int idClient)
            => await _service.DeleteClient(idClient);
    }
}
