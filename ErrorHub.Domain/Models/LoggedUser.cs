using ErrorHub.Domain.Entities.Interfaces;

namespace ErrorHub.Domain.Models
{
    public class LoggedUser : IUser
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Credentials { get; set; }
        public bool IsAdmin { get; set; }
    }
}
