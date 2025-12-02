using LocadoraDeAutomoveis.Aplicacao.ModuloCliente.DTOs;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCliente.Commands.SelecionarTodos
{
    public class SelecionarTodosClientesRequest : IRequest<IEnumerable<ClienteDto>>
    {
    }
}
