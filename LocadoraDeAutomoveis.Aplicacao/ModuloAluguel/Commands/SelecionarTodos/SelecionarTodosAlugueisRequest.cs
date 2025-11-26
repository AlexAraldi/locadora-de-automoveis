using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.DTOs;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.SelecionarTodos;

public class SelecionarTodosAlugueisRequest : IRequest<IEnumerable<AluguelDto>>
{
}
