using ErrorHub.Domain.Entities;
using ErrorHub.Domain.Models;
using ErrorHub.Domain.Services.Interfaces;
using ErrorHub.Domain.Utilities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace ErrorHub.Domain.Services
{
    public class JwtAuthenticationService : IAuthenticationService
    {
        private readonly SigningConfiguration _signingConfiguration;
        private readonly TokenConfiguration _tokenConfiguration;

        public JwtAuthenticationService(SigningConfiguration signingConfiguration, TokenConfiguration tokenConfiguration)
        {
            _signingConfiguration = signingConfiguration;
            _tokenConfiguration = tokenConfiguration;
        }

        public Authentication Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString()),
                new Claim("Data", Json.Convert(user))
            };

            var identity = new ClaimsIdentity(new GenericIdentity(user.Id.ToString(), "Login"), claims);
            var created = DateTime.UtcNow;
            var expiration = created + TimeSpan.FromSeconds(_tokenConfiguration.ExpirationInSeconds);
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.ValidIssuer,
                Audience = _tokenConfiguration.ValidAudience,
                SigningCredentials = _signingConfiguration.SigningCredentials,
                Subject = identity,
                NotBefore = created,
                Expires = expiration
            });

            var dateFormat = "yyyy-MM-dd HH:mm:ss";
            var result = new Authentication
            {
                Success = true,
                Authenticated = true,
                Created = created.ToString(dateFormat),
                Expiration = expiration.ToString(dateFormat),
                AccessToken = handler.WriteToken(securityToken),
                Message = "OK"
            };
            return result;
        }
    }
}
