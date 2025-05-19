using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trelite.API.DTO;
using Trelite.Business;
using Trelite.Business.Common;
using Trelite.Business.Interface;

namespace Trelite.API.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        protected readonly IAuthManager _authManager;
        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }
        [HttpPost("register")]
        public async Task<string> Register(RegisterDto registerDto)
        {
            var response = await _authManager.RegisterAsync(registerDto);
            if (response != null)
                BadRequest(response);
            return Message.SUCCESS_REGISTERATION;
        }

        [HttpPost("login")]
        public async Task<string> Login(LoginDto loginDto)
        {
            var response = await _authManager.LoginAsync(loginDto);
            if (response != null)
                BadRequest(response);
            return Message.SUCCESS_LOGIN;
        }
    }
}
