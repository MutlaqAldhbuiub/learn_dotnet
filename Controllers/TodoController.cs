using Microsoft.AspNetCore.Mvc;

namespace learn_dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get()
    {
        return Ok("Hello World!");
    }

    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
        return Ok($"Hello World! {id}");
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
        return Ok($"Deleted {id}");
    }
}
