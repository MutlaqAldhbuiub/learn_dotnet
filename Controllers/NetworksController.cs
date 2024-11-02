using learn_dotnet.Data;
using learn_dotnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace learn_dotnet.Controllers;


[ApiController]
// Route to the controller (api/networks) = by default it will be api/[controller] which means api/Networks
[Route("api/[controller]")]
public class NetworksController : ControllerBase
{
    private readonly INetworkRepo _repository = new MockNetworkRepo();

    // Get all networks
    [HttpGet]
    public ActionResult<IEnumerable<Network>> GetAllNetworks()
    {
        var networks = _repository.GetAllNetworks();
        return Ok(networks);
    }

    // Get a network by id
    [HttpGet("{id}")]
    public ActionResult<Network> GetNetworkById(int id)
    {
        // TODO:: does it run over validation here?
        var network = _repository.GetNetworkById(id);
        return Ok(network);
    }

}