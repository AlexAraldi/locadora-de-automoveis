using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.DTOs;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.SelecionarTodos
{
    public class SelecionarTodosFuncionariosRequestHandler : IRequestHandler<SelecionarTodosFuncionariosRequest,IEnumerable<FuncionarioDto>>
    {
        private readonly IFuncionarioRepository _repository;

        public SelecionarTodosFuncionariosRequestHandler(IFuncionarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FuncionarioDto>> Handle(SelecionarTodosFuncionariosRequest request, CancellationToken cancellationToken)
        {
            var lista = await _repository.SelecionarTodosAsync();

            return lista.Select(f => new FuncionarioDto
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
