using learn_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace learn_dotnet.Data;

public class NetworkContext : DbContext
{
    public NetworkContext(DbContextOptions<NetworkContext> options) : base(options)
    {
    }


    public DbSet<Network> Networks { get; set; }
}