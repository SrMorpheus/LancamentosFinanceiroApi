using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using LancamentosFinanceiroApi.Configurations;
using LancamentosFinanceiroApi.Services.Contract;
using Microsoft.IdentityModel.Tokens;

namespace LancamentosFinanceiroApi.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private TokenConfiguration _Configuration;


        public TokenService(TokenConfiguration configuration)
        {

            _Configuration = configuration;

        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration.Secret));

            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var options = new JwtSecurityToken(

                issuer: _Configuration.Issuer,

                audience: _Configuration.Audience,

                claims: claims,

                expires: DateTime.Now.AddMinutes(_Configuration.Minutes),

                signingCredentials: signinCredentials

                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(options);

            return tokenString;


        }

        public string GenerateRefreshToken()
        {

            var randomNumber = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {

                rng.GetBytes(randomNumber);

                return Convert.ToBase64String(randomNumber);

            };

        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {

                ValidateAudience = false,

                ValidateIssuer = false,

                ValidateIssuerSigningKey = true,

                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration.Secret)),

                ValidateLifetime = false


            };

            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

            var jwSecurityToken = securityToken as JwtSecurityToken;

            if (jwSecurityToken == null || !jwSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCulture)) throw new SecurityTokenException("Invvalid Token");

            return principal;


        }
    }
}
