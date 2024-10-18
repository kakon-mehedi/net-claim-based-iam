using IAM.Attributes;
using IAM.Models;
using IAM.Services;
using Microsoft.AspNetCore.Mvc;

namespace IAM.Controllers
{
    [Route("api/identity/v1/[controller]/[action]")]
    [ApiController]
    public class IamController : ControllerBase
    {
        private readonly IUserService _userService;
        public IamController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [ProtectedEndPoint]
        public IActionResult GetToken()
        {
            return Ok("1234");
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationModel model)
        {
            var result = await _userService.RegisterUser(model);

            return result.IsSuccess ? Ok(result) : BadRequest(result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _userService.Login(model);

            return result.IsSuccess ? Ok(result) : BadRequest(result.Errors);
        }


        [HttpPatch]
        public async Task<IActionResult> UpdateUser(UpdateUserModel updatedUser)
        {
            var result = await _userService.UpdateUser(updatedUser);

            return result.IsSuccess ? Ok(result) : BadRequest(result.Errors);
        }

        [HttpGet] 
        public async Task<IActionResult> GetUserById(string id)
        {
            var result = await _userService.GetUserById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Errors);
        }

    }
}
