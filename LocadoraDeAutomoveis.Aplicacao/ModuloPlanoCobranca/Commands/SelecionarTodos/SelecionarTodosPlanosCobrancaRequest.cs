using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.DTOs;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.SelecionarTodos;

public class SelecionarTodosPlanosCobrancaRequest : IRequest<IEnumerable<PlanoCobrancaDto>>
{ 
}
