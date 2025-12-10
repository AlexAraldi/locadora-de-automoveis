using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.DTOs;
using LocadoraDeAutomoveis.Dominio.ModuloAutenticacao;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using LocadoraDeAutomoveis.Infraestrutura.DataBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Service
{
    public class JwtService 
    {
        private readonly LocadoraDbContext dbContext;
        private readonly UserManager<Usuario> userManager;
        private readonly string _key;

        public JwtService(LocadoraDbContext dbContext, UserManager<Usuario> userManager, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            _key = configuration["JWT_GENERATION_KEY"];
        }

        public async Task<AccessToken> GerarToken(Usuario usuario)
        {
              var roles = await userManager.GetRolesAsync(usuario);

            var cargoDoUsuarioStr = roles.FirstOrDefault(); // Empresa / Funcionario

            if (cargoDoUsuarioStr is null)
                throw new Exception("Não foi possível recuperar os dados de permissão do usuário.");

            Guid? empresaId = null;

            if (cargoDoUsuarioStr == RoleUsuario.Funcionario.ToString())
            {
                // Se for funcionário, busca a empresa vinculada
                var funcionario = await dbContext.Set<Funcionario>()
                    .AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(f => f.UsuarioId == usuario.Id);

                if (funcionario is null)
                    throw new Exception("Funcionário não encontrado ou inativo.");

                empresaId = funcionario.EmpresaId;
            }
            else
            {
                empresaId = usuario.Id;
            }

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.UserName!),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email!),
                new Claim(ClaimTypes.Role, cargoDoUsuarioStr),
                new Claim("EmpresaId", empresaId.Value.ToString())
            };

            var expiracaoJwt = DateTime.UtcNow.AddMinutes(15);

            var chaveEmBytes = Encoding.ASCII.GetBytes(_key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "LocadoraDeVeiculos",
                Audience = "http://localhost:4200",
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(chaveEmBytes),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Expires = expiracaoJwt
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new AccessToken(
                tokenString,
                expiracaoJwt,
                new UsuarioAutenticado(
                    usuario.Id,
                    usuario.Email ?? string.Empty,
                    Enum.Parse<RoleUsuario>(cargoDoUsuarioStr)
                )
            );            
        }
    }
}