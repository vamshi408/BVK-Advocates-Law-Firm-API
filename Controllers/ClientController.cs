using BVK_Advocates_Law_Firm.IRepository;
using BVK_Advocates_Law_Firm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BVK_Advocates_Law_Firm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository) { 
        _clientRepository = clientRepository;
        }

        [HttpGet]
        public IActionResult GetClientList()
        {
            List<ClientModel> clients = new List<ClientModel>();
            try
            {
                clients=_clientRepository.GetAll();
            }
            catch {
            }
            return Ok(clients);
        }
    }
}
