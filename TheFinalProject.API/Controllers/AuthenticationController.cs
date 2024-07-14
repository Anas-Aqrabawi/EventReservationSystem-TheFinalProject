using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheFinalProject.core.DTOs;
using TheFinalProject.core.IServices;

namespace TheFinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly core.IServices.IAuthenticationService _authenticationService;

        public AuthenticationController(core.IServices.IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserCredentailsDTO userCredentailsDto)
        {
            var result = await _authenticationService.Login(userCredentailsDto);

            if (result is null)
            {
                return Unauthorized();
            }

            else
            {
                return Ok(result);
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task Register([FromBody] UserDTO userDto)
        {
            await _authenticationService.Register(userDto);
        }

        [HttpPost]
        [Route("HallOwnerRegister")]
        public async Task HallOwnerRegister(UserDTO userDto)
        {
            await _authenticationService.HallOwnerRegister(userDto);
        }
    }
}
