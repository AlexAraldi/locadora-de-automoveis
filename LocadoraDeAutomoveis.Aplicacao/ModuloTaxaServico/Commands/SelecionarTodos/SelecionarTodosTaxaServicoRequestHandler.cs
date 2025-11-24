using MediatR;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.DTOs;
using LocadoraDeAutomoveis.Dominio.ModuloTaxaServico;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.SelecionarTodos
{
    public class SelecionarTodasTaxasServicoRequestHandler : IRequestHandler<SelecionarTodasTaxasServicoRequest, List<TaxaServicoDto>>
    {
        private readonly ITaxaServicoRepository _repo;
        public SelecionarTodasTaxasServicoRequestHandler(ITaxaServicoRepository repo) => _repo = repo;

        public async Task<List<TaxaServicoDto>> Handle(SelecionarTodasTaxasServicoRequest request, CancellationToken cancellationToken)
        {
            var taxas = await _repo.SelecionarTodosAsync();
            return taxas.Select(t => new TaxaServicoDto { Id = t.Id, Nome = t.Nome, Valor = t.Valor, TipoCalculo = t.TipoCalculo }).ToList();
        }
    }
}
