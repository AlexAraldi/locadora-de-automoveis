using LocadoraDeAutomoveis.Dominio.ModuloTaxaServico;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.Editar
{
    public class EditarTaxaServicoRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public TipoCalculoTaxa TipoCalculo { get; set; }
    }
}
