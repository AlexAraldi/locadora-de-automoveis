using MediatR;
using LocadoraDeAutomoveis.Dominio.ModuloTaxaServico;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.Editar
{
    public class EditarTaxaServicoRequestHandler : IRequestHandler<EditarTaxaServicoRequest, bool>
    {
        private readonly ITaxaServicoRepository _repo;

        public EditarTaxaServicoRequestHandler(ITaxaServicoRepository repo) => _repo = repo;

        public async Task<bool> Handle(EditarTaxaServicoRequest request, CancellationToken cancellationToken)
        {
            var taxa = await _repo.SelecionarPorIdAsync(request.Id);
            if (taxa == null) return false;

            // se sua entidade tiver método Atualizar / Editar, use-o; senão atribua propriedades públicas
            taxa.Editar(request.Nome, request.Valor, request.TipoCalculo); // se existir
            await _repo.AtualizarAsync(taxa);
            return true;
        }
    }
}
