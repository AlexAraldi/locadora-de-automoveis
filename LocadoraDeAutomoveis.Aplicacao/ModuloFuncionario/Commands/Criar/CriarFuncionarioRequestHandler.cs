using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Validators;
using System.ComponentModel.DataAnnotations;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.DTOs;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Validators;
using LocadoraDeAutomoveis.Dominio.ModuloAutenticacao;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.Criar
{
    public class CriarFuncionarioRequestHandler : IRequestHandler<CriarFuncionarioRequest, object>
    {
        private readonly IFuncionarioRepository _repository;
        private readonly CriarFuncionarioValidator _validator;
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<Cargo> _roleManager;
        private readonly ITenantProvider _tenantProvider;

        public CriarFuncionarioRequestHandler(
            IFuncionarioRepository repository, 
            UserManager<Usuario> userManager, 
            CriarFuncionarioValidator validator, 
            RoleManager<Cargo> roleManager,
            ITenantProvider tenantProvider
        )
        {
            _repository = repository;
            _validator =  validator;
            _userManager = userManager;
            _roleManager = roleManager;
            _tenantProvider = tenantProvider;
        }

        public async Task<object> Handle(CriarFuncionarioRequest request , CancellationToken cancellationToken)
        {
            var validation = _validator.Validate(request);
            if (!validation.IsValid)
                return validation.Errors.Select(x => x.ErrorMessage);

            var existente = await _repository.BuscarPorEmailAsync(request.Email);
            if (existente != null)
                return FuncionarioErrorResults.EmailJaCadastrado;

            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                UserName = request.Email

            };
            await _userManager.CreateAsync(usuario, request.Senha);

            var cargoStr = RoleUsuario.Funcionario.ToString();

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

            var funcionario = new Funcionario
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Email = request.Email,
                Cargo = request.Cargo,
                DataAdmissao = request.DataAdmissao,
                Salario = request.Salario,
                UsuarioId = usuario.Id,
                EmpresaId = _tenantProvider.EmpresaId.GetValueOrDefault(),
            };

            await _repository.AdicionarAsync(funcionario);

            return new FuncionarioDto
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Email = funcionario.Email,
                Cargo = funcionario.Cargo,
                DataAdmissao = funcionario.DataAdmissao,
                Salario = funcionario.Salario
            };
        }
    }
}
