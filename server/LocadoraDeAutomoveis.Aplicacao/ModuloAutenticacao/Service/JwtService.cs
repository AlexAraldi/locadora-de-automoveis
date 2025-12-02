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

        public async Task<TokenResponse> GerarToken(Usuario usuario)
        {
            var roles = await userManager.GetRolesAsync(usuario);

            var cargoDoUsuarioStr = roles.FirstOrDefault();

            if (cargoDoUsuarioStr is null)
                throw new Exception("Não foi possível recuperar os dados de permissão do usuário.");

            Guid empresaId;

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
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email!),
                new Claim(ClaimTypes.Role, cargoDoUsuarioStr),
                new Claim("EmpresaId", empresaId.ToString())                
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
