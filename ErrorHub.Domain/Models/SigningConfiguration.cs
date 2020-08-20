using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ErrorHub.Domain.Models
{
    public sealed class SigningConfiguration
    {
        public SecurityKey Key { get; set; }
        public SigningCredentials SigningCredentials { get; set; }

        public SigningConfiguration(TokenConfiguration token)
        {
            var secret = Encoding.ASCII.GetBytes(token.Secret);
            Key = new SymmetricSecurityKey(secret);
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);

        }
    }
}
