using ErrorHub.Domain.Entities.Interfaces;
using ErrorHub.Domain.Models;
using ErrorHub.Domain.Services.Interfaces;

namespace ErrorHub.Domain.Services
{
    public class FakeAuthorizationService : IAuthorizationService
    {
        public Result<IUser> Authorize(LoginDomain userData)
        {
            var result = new Result<IUser>();

            if (userData.email == "rames.wiz@outlook.com" && userData.password == "1234567890")
            {
                result.Success = true;
                result.Message = "User authorized.";
                result.Data = new LoggedUser
                {
                    Id = 1,
                    Name = userData.email,
                    Credentials = "01|02|09",
                    IsAdmin = false
                };
            }
            else
            {
                result.Success = false;
                result.Message = "Not authorized.";
            }

            return result;
        }
    }
}
