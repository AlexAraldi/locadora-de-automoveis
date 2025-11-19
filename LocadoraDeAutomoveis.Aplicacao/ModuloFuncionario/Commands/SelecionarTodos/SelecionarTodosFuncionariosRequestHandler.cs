using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.DTOs;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.SelecionarTodos
{
    public class SelecionarTodosFuncionariosRequestHandler
    {
        private readonly IFuncionarioRepository _repository;

        public SelecionarTodosFuncionariosRequestHandler(IFuncionarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FuncionarioDto>> Handle()
        {
            var funcionarios = await _repository.SelecionarTodos();

            return funcionarios.Select(f => new FuncionarioDto
            {
                Id = f.Id,
                Nome = f.Nome,
                Email = f.Email,
                Cargo = f.Cargo,
                DataAdmissao = f.DataAdmissao,
                Salario = f.Salario
            });
        }
    }
}
