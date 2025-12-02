using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCliente.Commands.Excluir
{
    public class ExcluirClienteRequest : IRequest<object>
    {
        public Guid Id { get; set; }
    }
}
