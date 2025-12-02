using LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.DTOs;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.Commands.SelecionarTodos
{
    public class SelecionarTodasDevolucoesRequest : IRequest<IEnumerable<DevolucaoDto>>
    {
    }
}
