using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.DTOs;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Validators;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.Criar
{
    public class CriarFuncionarioRequestHandler
    {
        private readonly IFuncionarioRepository _repository;
        private readonly CriarFuncionarioValidator _validator;

        public CriarFuncionarioRequestHandler(IFuncionarioRepository repository)
        {
            _repository = repository;
            _validator = new CriarFuncionarioValidator();
        }

        public async Task<object> Handle(CriarFuncionarioRequest request)
        {
            var validation = _validator.Validate(request);
            if (!validation.IsValid)
                return validation.Errors.Select(x => x.ErrorMessage);

            var existente = await _repository.BuscarPorEmailAsync(request.Email);
            if (existente != null)
                return FuncionarioErrorResults.EmailJaCadastrado;

            var funcionario = new Funcionario
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Email = request.Email,
                Cargo = request.Cargo,
                DataAdmissao = request.DataAdmissao,
                Salario = request.Salario
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
