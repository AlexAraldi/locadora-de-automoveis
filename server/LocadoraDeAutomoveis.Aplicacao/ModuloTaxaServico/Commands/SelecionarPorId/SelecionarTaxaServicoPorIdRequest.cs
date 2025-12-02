using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.DTOs;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.SelecionarPorId
{
    public class SelecionarTaxaServicoPorIdRequest : IRequest<TaxaServicoDto?>
    {
        public Guid Id { get; set; }

        public SelecionarTaxaServicoPorIdRequest() { }
        public SelecionarTaxaServicoPorIdRequest(Guid id) => Id = id;
    }
}
