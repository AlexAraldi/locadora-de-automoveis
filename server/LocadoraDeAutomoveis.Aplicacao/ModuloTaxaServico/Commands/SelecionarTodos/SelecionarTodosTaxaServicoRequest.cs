using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.DTOs;
using MediatR;
using System.Collections.Generic;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.SelecionarTodos
{
    public class SelecionarTodasTaxasServicoRequest : IRequest<List<TaxaServicoDto>>
    {
    }
}
