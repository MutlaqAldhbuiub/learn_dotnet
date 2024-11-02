namespace learn_dotnet.Models;


public class Network
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Ip { get; set; }
    public int Capacity { get; set; }
}