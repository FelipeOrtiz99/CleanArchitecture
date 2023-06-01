using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly IAuthService _aurthservice;

        public AccountController(IAuthService aurthservice)
        {
            _aurthservice = aurthservice;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody]AuthRequest request)
        {
            return Ok(await _aurthservice.Login(request));
        }
        [HttpPost("Register")]
        public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegistrationRequest request)
        {
            return Ok(await _aurthservice.Register(request));
        }




    }
}
