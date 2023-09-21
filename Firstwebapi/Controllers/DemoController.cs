using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Firstwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet("Demo/Add")]
        public int Add(int a, int b)
        {
            return a + b + 15000;
        }
    }
}
