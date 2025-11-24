using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.Excluir
{
    public class ExcluirTaxaServicoRequest : IRequest<bool>
    {
        public Guid Id { get; set; }

        // opcional: construtor para conveniência
        public ExcluirTaxaServicoRequest() { }
        public ExcluirTaxaServicoRequest(Guid id) => Id = id;
    }
}
