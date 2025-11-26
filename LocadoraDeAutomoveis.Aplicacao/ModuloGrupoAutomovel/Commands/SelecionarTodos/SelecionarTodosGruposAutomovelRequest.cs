using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.DTOs;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.SelecionarTodos;

public class SelecionarTodosGruposAutomovelRequest : IRequest<IEnumerable<GrupoAutomovelDto>>
{ 
}
