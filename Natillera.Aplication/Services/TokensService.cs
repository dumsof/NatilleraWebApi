namespace Natillera.Aplication.Services
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Natillera.AplicationContract.IServices;
    using Natillera.AplicationContract.Models.RefreshToken;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;

    public class TokensService : ITokensService
    {
        private readonly IConfiguration configuration;

        public TokensService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public RespuestaToken GenerateTokenRefresh()
        {
            var randomNumber = new byte[32];
            string refreshToken;
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomNumber);
                refreshToken = Convert.ToBase64String(randomNumber);
            }

            return new RespuestaToken
            {
                Token = refreshToken,
                FechaExpiracion = DateTime.UtcNow.AddMonths(7)
            };
        }

        public RespuestaToken CrearToken(string usuarioId, string nombreUsuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, usuarioId),
                new Claim(JwtRegisteredClaimNames.UniqueName, nombreUsuario), //se puede pasar cualquier valor 
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) //valor unico por token, identificador para poder revocar el token si se desea.
            };

            //la clave secrete debe tener una longitud de mas de 128 bit.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["va_clave_super_secreta"]));
            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            int horaVencimientoToken = this.configuration.GetValue<int>("Token:HorasVencimientoToken");

            var expiration = DateTime.Now.AddHours(horaVencimientoToken);

            JwtSecurityToken token = new JwtSecurityToken(
                                                           issuer: this.configuration.GetValue<string>("Token:Issuer"),
                                                           audience: this.configuration.GetValue<string>("Token:Audience"),
                                                           claims: claims,
                                                           expires: expiration,
                                                           signingCredentials: credencial
                                    );
            return new RespuestaToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                FechaExpiracion = expiration
            };
        }

        public string GetUserFromAccessToken(string tokenAcceso)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(this.configuration["va_clave_super_secreta"]);
            var vokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuers = new List<string> { this.configuration.GetValue<string>("Token:Issuer") },
                ValidAudience = this.configuration.GetValue<string>("Token:Audience"),
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero
            };

            SecurityToken securityToken;
            //DUM: contiene los datos del token despues de desencriptarlos, información de claim
            var principal = tokenHandler.ValidateToken(tokenAcceso, vokenValidationParameters, out securityToken);
            JwtSecurityToken jwtSecurityToken = (JwtSecurityToken)securityToken;

            string usuario = string.Empty;
            if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                usuario = principal.FindFirst(ClaimTypes.Name)?.Value;
            }

            return usuario;
        }

        public RespuestaToken CrearToken2ASCII(string usuarioId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.configuration["va_clave_super_secreta"]);
            var expiration = DateTime.UtcNow.AddSeconds(7);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Convert.ToString(usuarioId))
                }),
                Expires = expiration,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenCreado = tokenHandler.WriteToken(token);

            return new RespuestaToken
            {
                Token = tokenCreado,
                FechaExpiracion = expiration
            };
        }
    }
}
