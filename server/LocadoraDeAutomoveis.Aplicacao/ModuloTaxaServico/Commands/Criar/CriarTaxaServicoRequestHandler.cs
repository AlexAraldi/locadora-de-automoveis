using MediatR;
using LocadoraDeAutomoveis.Dominio.ModuloTaxaServico;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.Criar
{
    public class CriarTaxaServicoRequestHandler : IRequestHandler<CriarTaxaServicoRequest, Guid>
    {
        private readonly ITaxaServicoRepository _repo;

        public CriarTaxaServicoRequestHandler(ITaxaServicoRepository repo) => _repo = repo;

        public async Task<Guid> Handle(CriarTaxaServicoRequest request, CancellationToken cancellationToken)
        {
            var taxa = new TaxaServico(request.Nome, request.Valor, request.TipoCalculo);
            await _repo.AdicionarAsync(taxa);
            return taxa.Id;
        }
    }
}
