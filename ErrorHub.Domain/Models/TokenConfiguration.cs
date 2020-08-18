﻿namespace ErrorHub.Domain.Models
{
    public class TokenConfiguration
    {
        public const string Policy = "Bearer";
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
        public int ExpirationInSeconds { get; set; }
        public bool ValidateLifetime { get; set; }
        public bool ValidadeIssuerSigningKey { get; set; }
    }
}
