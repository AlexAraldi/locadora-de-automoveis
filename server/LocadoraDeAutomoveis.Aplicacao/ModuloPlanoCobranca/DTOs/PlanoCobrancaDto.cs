namespace LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.DTOs;

public class PlanoCobrancaDto
{
    public Guid Id { get; set; }
    public Guid GrupoAutomovelId { get; set; }
    public string TipoPlano { get; set; } = string.Empty;
    public decimal ValorDiaria { get; set; }
    public decimal? ValorPorKm { get; set; }
    public int? KmLivre { get; set; }
    public int? KmControladoLimite { get; set; }
    public decimal? ValorExcedenteKm { get; set; }
}
