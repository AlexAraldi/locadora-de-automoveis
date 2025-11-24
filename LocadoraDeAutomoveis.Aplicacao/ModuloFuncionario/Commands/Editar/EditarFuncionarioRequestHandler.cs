using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.DTOs;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Validators;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.Editar
{
    public class EditarFuncionarioRequestHandler
    {
        private readonly IFuncionarioRepository _repository;
        private readonly EditarFuncionarioValidator _validator;

        public EditarFuncionarioRequestHandler(IFuncionarioRepository repository)
        {
            _repository = repository;
            _validator = new EditarFuncionarioValidator();
        }

        public async Task<object> Handle(EditarFuncionarioRequest request)
        {
            var validation = _validator.Validate(request);
            if (!validation.IsValid)
                return validation.Errors.Select(x => x.ErrorMessage);

            var funcionario = await _repository.SelecionarPorIdAsync(request.Id);
            if (funcionario == null)
                return FuncionarioErrorResults.FuncionarioNaoEncontrado;

            var emailDuplicado = await _repository.BuscarPorEmailAsync(request.Email);
            if (emailDuplicado != null && emailDuplicado.Id != request.Id)
                return FuncionarioErrorResults.EmailJaCadastrado;

            funcionario.Nome = request.Nome;
            funcionario.Email = request.Email;
            funcionario.Cargo = request.Cargo;
            funcionario.DataAdmissao = request.DataAdmissao;
            funcionario.Salario = request.Salario;

            await _repository.AtualizarAsync(funcionario);

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
