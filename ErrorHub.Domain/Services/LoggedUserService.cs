using ErrorHub.Domain.Entities.Interfaces;
using ErrorHub.Domain.Models;
using ErrorHub.Domain.Services.Interfaces;
using ErrorHub.Domain.Utilities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ErrorHub.Domain.Services
{
    public class LoggedUserService : ILoggedUserService
    {
        private readonly IHttpContextAccessor _accessor;

        public LoggedUserService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public Result<T> GetLoggedUser<T>() where T : class, IUser
        {
            var identity = _accessor.HttpContext?.User?.Identity as ClaimsIdentity;
            var result = new Result<T>();

            if (identity?.IsAuthenticated ?? false)
            {
                result.Data = Json.From<T>(identity?.FindFirst("Data")?.Value);
                result.Success = result.Data != null;
            }

            return result;
        }
    }
}
