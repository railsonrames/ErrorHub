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

        /// <summary>
        /// Autentica e gera o token JWT que precisamos para acessas os outros endpoint da aplicação.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST
        ///     {
        ///        "email": "rames.wiz@outlook.com",
        ///        "password": "senha"
        ///     }
        ///
        /// </remarks>
        /// <param email="string"></param>
        /// <param senha="string"></param>
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
        [Route("authenticated")]
        [Authorize]
        public ActionResult Authenticated()
        {
            return Ok("User Authenticated");
        }
    }
}
