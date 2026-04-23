using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1_exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorld : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello word from C# using an API");
        }
    }
}
