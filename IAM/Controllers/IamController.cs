using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IAM.Controllers
{
    [Route("api/identity/v1/[controller]/[action]")]
    [ApiController]
    public class IamController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetToken()
        {
            return Ok("1234");
        }
    }
}
