using LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.DTOs;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Commands.SelecionarTodos
{
    public class SelecionarTodosCondutoresRequest : IRequest<IEnumerable<CondutorDto>>
    {
    }
}


