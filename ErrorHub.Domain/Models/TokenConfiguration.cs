namespace ErrorHub.Domain.Models
{
    public sealed class TokenConfiguration
    {
        public const string Policy = "Bearer";
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
        public bool ValidadeIssuerSigningKey { get; set; }
        public bool ValidateLifetime { get; set; }
        public int ExpirationInSeconds { get; set; }
        public string Secret { get; set; }
    }
}
