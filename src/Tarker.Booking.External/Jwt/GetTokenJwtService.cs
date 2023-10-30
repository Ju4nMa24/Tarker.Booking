using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Tarker.Booking.Application.External.Jwt;
using Tarker.Booking.Domain.Enums.Jwt;

namespace Tarker.Booking.External.Jwt
{
    public class GetTokenJwtService : IGetTokenJwtService
    {
        private readonly IConfiguration _configuration;
        /// <summary>
        /// Constructor DI.
        /// </summary>
        /// <param name="configuration"></param>
        public GetTokenJwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// This method is used to jwt generate.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        public string Execute(string id)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            string key = _configuration["SecretKeyJwt"] ?? string.Empty;
            SigningCredentials signing = new(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature);
            string algorithm = _configuration["Algorithm"] ?? string.Empty;
            if (Enum.TryParse(algorithm, out Algorithm enumAlg))
            {
                switch (enumAlg)
                {
                    case Algorithm.EcdsaSha256:
                        ECDsa privateKey = ECDsa.Create();
                        signing = new SigningCredentials(new ECDsaSecurityKey(privateKey), SecurityAlgorithms.EcdsaSha256);
                        break;
                }
            }
            SecurityToken token = tokenHandler.CreateToken(new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, id),
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = signing,
                Issuer = _configuration["IssuerJwt"],
                Audience = _configuration["AudienceJwt"]
            });
            return tokenHandler.WriteToken(token);
        }
    }
}
