using Microsoft.AspNetCore.Mvc;

namespace YarpSample.Proxy.Controllers;

[ApiController]
[Route("[controller]")]
public class SampleController : ControllerBase
{
    private readonly ILogger<SampleController> _logger;

    public SampleController(ILogger<SampleController> logger) => _logger = logger;

    [HttpGet]
    public IEnumerable<int> Get() => Enumerable.Range(1, 5);
}