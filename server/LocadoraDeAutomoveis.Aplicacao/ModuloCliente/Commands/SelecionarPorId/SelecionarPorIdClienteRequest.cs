using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCliente.Commands.SelecionarPorId
{
    public class SelecionarClientePorIdRequest : IRequest<object>
    {
        public Guid Id { get; set; }
    }
}
