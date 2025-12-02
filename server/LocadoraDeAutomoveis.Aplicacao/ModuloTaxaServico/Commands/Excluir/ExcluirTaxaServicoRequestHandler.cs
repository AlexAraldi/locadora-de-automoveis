using MediatR;
using LocadoraDeAutomoveis.Dominio.ModuloTaxaServico;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.Excluir
{
    public class ExcluirTaxaServicoRequestHandler : IRequestHandler<ExcluirTaxaServicoRequest, bool>
    {
        private readonly ITaxaServicoRepository _repo;
        public ExcluirTaxaServicoRequestHandler(ITaxaServicoRepository repo) => _repo = repo;

        public async Task<bool> Handle(ExcluirTaxaServicoRequest request, CancellationToken cancellationToken)
        {
            var taxa = await _repo.SelecionarPorIdAsync(request.Id);
            if (taxa == null) return false;
            await _repo.ExcluirAsync(taxa);
            return true;
        }
    }
}
