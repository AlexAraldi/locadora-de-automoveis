namespace LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.DTOs;

public class AluguelDto
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public Guid CondutorId { get; set; }
    public Guid VeiculoId { get; set; }
    public Guid GrupoAutomovelId { get; set; }
    public Guid PlanoCobrancaId { get; set; }

    public DateTime DataInicio { get; set; }
    public DateTime DataPrevistaTermino { get; set; }
    public decimal ValorPrevisto { get; set; }

    public int? KmFinal { get; set; }
    public decimal? ValorFinal { get; set; }
    public decimal? ValorMultas { get; set; }

    public string Situacao { get; set; } = string.Empty;
}
