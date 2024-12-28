using eCommerce.Core.DTO;
using eCommerce.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")] //api/auth
    [ApiController]
    public class AuthController(IUsersService usersService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest? registerRequest)
        {
            if (registerRequest == null) return BadRequest("Invalid registration data.");

            var authenticationResponse = await usersService.Register(registerRequest);

            if (authenticationResponse == null || authenticationResponse.Success == false)
                return BadRequest("Failed to register.");

            return Ok(authenticationResponse);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest? loginRequest)
        {
            if (loginRequest == null) return BadRequest("Invalid login data.");

            var authenticationResponse = await usersService.Login(loginRequest);

            if (authenticationResponse == null || authenticationResponse.Success == false)
                return Unauthorized("Login failed: Incorrect Username/Password.");

            return Ok(authenticationResponse);
        }

    }
}
