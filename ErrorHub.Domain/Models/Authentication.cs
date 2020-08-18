namespace ErrorHub.Domain.Models
{
    public class Authentication : Result<object>
    {
        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AccessToken { get; set; }
    }
}
