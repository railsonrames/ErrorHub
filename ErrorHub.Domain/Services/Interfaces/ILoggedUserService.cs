using ErrorHub.Domain.Entities.Interfaces;
using ErrorHub.Domain.Models;

namespace ErrorHub.Domain.Services.Interfaces
{
    public interface ILoggedUserService
    {
        Result<T> GetLoggedUser<T>() where T : class, IUser;
    }
}
