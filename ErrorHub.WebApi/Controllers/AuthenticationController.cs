using ErrorHub.Domain.Models;
using ErrorHub.Domain.Services.Interfaces;
using ErrosHub.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHub.WebApi.Controllers
{
    [Route("api/login")]
    [ApiController]
    public sealed class AuthenticationController : ControllerBase
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
                email = userData.Email,
                password = userData.Password
            });

            if (!authorization.Success)
                return Ok(authorization);

            var authentication = _authenticationService.Authenticate(authorization.Data);

            if (!authentication.Success)
                return Ok(authentication);

            return Ok(authentication);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var usersList = _userService.GetAll();
            return Ok(usersList);
        }
    }
}
