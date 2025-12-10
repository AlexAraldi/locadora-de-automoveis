using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Validators;
using LocadoraDeAutomoveis.InfraEstrutura.ModuloAutenticacao.Repositories;
using LocadoraDeAutomoveis.Dominio.ModuloAutenticacao;
using MediatR;
using Microsoft.AspNetCore.Identity;
using FluentResults;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Commands.Registrar
{
    public class RegistrarUsuarioRequestHandler : IRequestHandler<RegistrarUsuarioRequest, object>
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly RegistrarUsuarioValidator _validator;
        private readonly RoleManager<Cargo> _roleManager;

        public RegistrarUsuarioRequestHandler(
          UserManager<Usuario> userManager,
          RegistrarUsuarioValidator validator,            
          RoleManager<Cargo> roleManager
        )
        {
            _userManager = userManager;
            _validator = validator;
            _roleManager = roleManager;
        }

        public async Task<object> Handle(RegistrarUsuarioRequest request, CancellationToken cancellationToken)
        {
            var validation = _validator.Validate(request);
            if (!validation.IsValid)
                return validation.Errors.Select(x => x.ErrorMessage);

            // Já existe usuário com este e-mail?
            var existente = await _userManager.FindByEmailAsync(request.Email);
            if (existente != null)
                return AutenticacaoErrorResults.EmailJaRegistrado;

            // Criação do usuário
            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                UserName = request.Email,
                EmpresaId = Guid.NewGuid()

            };
            usuario.EmpresaId = usuario.Id;

            await _userManager.CreateAsync(usuario, request.Senha);

            var cargoStr = RoleUsuario.Empresa.ToString();

            var resultadoBuscaCargo = await _roleManager.FindByNameAsync(cargoStr);

            if (resultadoBuscaCargo is null)
            {
                var cargo = new Cargo()
                {
                    Name = cargoStr,
                    NormalizedName = cargoStr.ToUpperInvariant(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                };

                await _roleManager.CreateAsync(cargo);
            }

            await _userManager.AddToRoleAsync(usuario, cargoStr);
         
            return new
            {
                Mensagem = "Usuário registrado com sucesso.",
                UsuarioId = usuario.Id
            };

        }
    }
}
