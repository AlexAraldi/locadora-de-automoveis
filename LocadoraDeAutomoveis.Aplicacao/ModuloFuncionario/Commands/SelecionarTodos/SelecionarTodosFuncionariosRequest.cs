using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.DTOs;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.SelecionarTodos
{
    public class SelecionarTodosFuncionariosRequest : IRequest<IEnumerable<FuncionarioDto>>
    { 
    }
}
