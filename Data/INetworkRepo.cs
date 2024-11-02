using learn_dotnet.Models;

namespace learn_dotnet.Data;

// Interface for the network repository (Implements the CRUD operations)
public interface INetworkRepo
{
    // Get all networks
    IEnumerable<Network> GetAllNetworks();

    // Get a network by id
    Network GetNetworkById(int id);

}