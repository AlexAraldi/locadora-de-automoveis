using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCliente.Commands.Excluir
{
    public class ExcluirClienteRequestHandler : IRequestHandler<ExcluirClienteRequest, object>
    {
        private readonly IClienteRepository _repository;

        public ExcluirClienteRequestHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> Handle(ExcluirClienteRequest request, CancellationToken cancellationToken)
        {
            var cliente = await _repository.SelecionarPorIdAsync(request.Id);

            if (cliente == null)
                return ClienteErrorResults.ClienteNaoEncontrado;

            await _repository.ExcluirAsync(cliente);

            return new { Mensagem = "Cliente excluído com sucesso." };
        }
    }
}
