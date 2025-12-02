using LocadoraDeAutomoveis.Dominio.ModuloTaxaServico;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.Criar
{
    public class CriarTaxaServicoRequest : IRequest<Guid>
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public TipoCalculoTaxa TipoCalculo { get; set; }
    }
}
