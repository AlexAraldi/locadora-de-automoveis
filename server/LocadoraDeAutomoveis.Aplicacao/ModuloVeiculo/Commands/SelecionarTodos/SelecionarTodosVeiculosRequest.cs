using LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.DTOs;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.SelecionarTodos;

public class SelecionarTodosVeiculosRequest : IRequest<IEnumerable<VeiculoDto>>
{
}
