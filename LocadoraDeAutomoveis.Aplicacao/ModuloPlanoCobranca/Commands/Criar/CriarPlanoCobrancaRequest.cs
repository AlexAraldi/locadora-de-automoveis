using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.Criar;

public class CriarPlanoCobrancaRequest : IRequest<object>
{
    public Guid GrupoAutomovelId { get; set; }
    public TipoPlano TipoPlano { get; set; }
    public decimal ValorDiaria { get; set; }
    public decimal? ValorPorKm { get; set; }
    public int? KmLivre { get; set; }
    public int? KmControladoLimite { get; set; }
    public decimal? ValorExcedenteKm { get; set; }
}
