using ErrorHub.Domain.Entities.Interfaces;
using ErrorHub.Domain.Models;

namespace ErrorHub.Domain.Services.Interfaces
{
    public interface IAuthorizationService
    {
        Result<IUser> Authorize(LoginDomain userData);
    }
}
