using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.DTOs;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.SelecionarPorId
{
    public class SelecionarFuncionarioPorIdRequestHandler : IRequestHandler<SelecionarFuncionarioPorIdRequest, object>
    {
        private readonly IFuncionarioRepository _repository;

        public SelecionarFuncionarioPorIdRequestHandler(IFuncionarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> Handle(SelecionarFuncionarioPorIdRequest request, CancellationToken cancellationToken)
        {
            var funcionario = await _repository.SelecionarPorIdAsync(request.Id);

            if (funcionario == null)
                return FuncionarioErrorResults.FuncionarioNaoEncontrado;

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
