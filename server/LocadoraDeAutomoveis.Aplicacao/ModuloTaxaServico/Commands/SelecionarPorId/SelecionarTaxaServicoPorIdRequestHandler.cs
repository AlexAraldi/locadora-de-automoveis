using MediatR;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.DTOs;
using LocadoraDeAutomoveis.Dominio.ModuloTaxaServico;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.SelecionarPorId
{
    public class SelecionarTaxaServicoPorIdRequestHandler : IRequestHandler<SelecionarTaxaServicoPorIdRequest, TaxaServicoDto?>
    {
        private readonly ITaxaServicoRepository _repo;
        public SelecionarTaxaServicoPorIdRequestHandler(ITaxaServicoRepository repo) => _repo = repo;

        public async Task<TaxaServicoDto?> Handle(SelecionarTaxaServicoPorIdRequest request, CancellationToken cancellationToken)
        {
            var t = await _repo.SelecionarPorIdAsync(request.Id);
            if (t == null) return null;
            return new TaxaServicoDto { Id = t.Id, Nome = t.Nome, Valor = t.Valor, TipoCalculo = t.TipoCalculo };
        }
    }
}
