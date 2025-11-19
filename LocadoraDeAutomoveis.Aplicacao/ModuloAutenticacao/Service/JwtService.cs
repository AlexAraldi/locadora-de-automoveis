using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.DTOs;
using LocadoraDeAutomoveis.Dominio.ModuloAutenticacao;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Service
{
    public class JwtService
    {
        private readonly string _key;

        public JwtService(string key)
        {
            _key = key;
        }

        public TokenResponse GerarToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Role.ToString())
            };

            var keyBytes = Encoding.UTF8.GetBytes(_key);
            var creds = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: creds
            );

            return new TokenResponse
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresIn = 8 * 3600
            };
        }
    }
}
