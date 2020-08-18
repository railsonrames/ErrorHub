using ErrorHub.Domain.Models;
using ErrorHub.Domain.Services.Interfaces;
using ErrosHub.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHub.WebApi.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;

        public AuthenticationController(IAuthenticationService authenticationService, IUserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] LoginVM userData)
        {
            var authorization = _userService.Authorize(new LoginDomain
            {
                email = userData.email,
                password = userData.password
            });

            if (!authorization.Success)
                return Ok(authorization);

            var authentication = _authenticationService.Authenticate(authorization.Data);

            if (!authentication.Success)
                return Ok(authentication);

            return Ok(authentication);
        }
    }
}
