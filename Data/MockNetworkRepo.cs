using learn_dotnet.Models;

namespace learn_dotnet.Data;

public class MockNetworkRepo : INetworkRepo
{
    public IEnumerable<Network> GetAllNetworks()
    {
        var networks = new List<Network>
        {
            new Network { Id = 0, Name = "Test Network", Ip = "192.168.1.1", Capacity = 100 },
            new Network { Id = 1, Name = "Test Network 2", Ip = "192.168.1.2", Capacity = 200 },
            new Network { Id = 2, Name = "Test Network 3", Ip = "192.168.1.3", Capacity = 300 },
        };
        return networks;
    }

    public Network? GetNetworkById(int id)
    {
        // Check if the id is valid, if not return 404
        // if (id > GetAllNetworks().Count())
        // {
        //     return null;
        // }

        return GetAllNetworks().FirstOrDefault(n => n.Id == id);
    }
}