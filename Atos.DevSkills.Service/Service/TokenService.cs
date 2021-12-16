using Atos.DevSkills.Domain.Model;
using Atos.DevSkills.Domain.Config;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Atos.DevSkills.Service.Service
{
    public static class TokenService
    {

        public static string GenerateToken(Manager manager)
        {
            //Manipulador do TOKEN
            var tokenHandler = new JwtSecurityTokenHandler();
            //Recuperando a chave em um formato de array de bytes
            var key = Encoding.ASCII.GetBytes(Config.JwtKey);
            //As configurações do TOKEN
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, manager.Nome),             //User.Identity.Name
                    new Claim(ClaimTypes.Role, manager.Role.ToString())           //User.IsInRole
                   
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    algorithm: SecurityAlgorithms.HmacSha256Signature)
            };

            //Criando efetivamente o TOKEN
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
