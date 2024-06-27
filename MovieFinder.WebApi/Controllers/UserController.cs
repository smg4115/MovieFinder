using MovieFinder.Models.Responses;
using MovieFinder.Models.User;
using MovieFinder.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace MovieFinder.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegister model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = await _userService.RegisterUserAsync(model);
            if (registerResult)
            {
                TextResponse response = new("User was registered.");
                return Ok(response);
            }

            return BadRequest(new TextResponse("User could not be registered."));
        }

        [HttpGet("{UserId:int}")]
        public async Task<IActionResult> GetById()
        {
            UserDetail? detail = await _userService.GetUserByIdAsync(userId);

            if (detail is null)
            {
                return NotFound();
            }

            return Ok(detail);
        }
    }
}