using ErrorHub.Domain.Entities;
using ErrorHub.Domain.Models;

namespace ErrorHub.Domain.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Authentication Authenticate(User user);
    }
}
