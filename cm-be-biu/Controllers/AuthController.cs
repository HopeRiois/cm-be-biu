using cm_be_biu.Requests;
using cm_be_biu.Responses;
using cm_be_biu.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cm_be_biu.Controllers
{
    [ApiController]
    [Route("auth")]
    public sealed class AuthController(AuthService authService) : ControllerBase
    {

        private readonly AuthService _authService = authService;

        [AllowAnonymous]
        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> HandleLogin(AuthRequest request)
        {
            AuthResponse? response = await _authService.HandleLogin(request);
            if (response == null) return Unauthorized();
            return Ok(response);
        }

    }
}
