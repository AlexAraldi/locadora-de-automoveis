using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.Excluir
{
    public class ExcluirFuncionarioRequestHandler : IRequestHandler<ExcluirFuncionarioRequest,object>
    {
        private readonly IFuncionarioRepository _repository;

        public ExcluirFuncionarioRequestHandler(IFuncionarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> Handle(ExcluirFuncionarioRequest request, CancellationToken cancellationToken)
        {
            var funcionario = await _repository.SelecionarPorIdAsync(request.Id);
            if (funcionario == null)
                return FuncionarioErrorResults.FuncionarioNaoEncontrado;

            await _repository.ExcluirAsync(funcionario);

            return new
            {
                Mensagem = "Funcionário excluído com sucesso."
            };
        }
    }
}
