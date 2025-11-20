namespace LocadoraDeAutomoveis.Dominio.ModuloAluguel;

public class Aluguel
{
    public Guid Id { get; private set; }

    public Guid ClienteId { get; private set; }
    public Guid CondutorId { get; private set; }
    public Guid VeiculoId { get; private set; }
    public Guid GrupoAutomovelId { get; private set; }
    public Guid PlanoCobrancaId { get; private set; }

    public DateTime DataInicio { get; private set; }
    public DateTime DataPrevistaTermino { get; private set; }

    public SituacaoAluguel Situacao { get; private set; }

    // Valores previstos (calculados na criação do aluguel)
    public decimal ValorPrevisto { get; private set; }

    // Informações da devolução serão preenchidas somente no módulo devolução
    public DateTime? DataDevolucao { get; private set; }
    public decimal? ValorFinal { get; private set; }
    public int? KmFinal { get; private set; }
    public decimal? ValorMultas { get; private set; }

    public Aluguel() { }

    public Aluguel(
        Guid clienteId,
        Guid condutorId,
        Guid veiculoId,
        Guid grupoAutomovelId,
        Guid planoCobrancaId,
        DateTime dataInicio,
        DateTime dataPrevistaTermino,
        decimal valorPrevisto)
    {
        Id = Guid.NewGuid();
        ClienteId = clienteId;
        CondutorId = condutorId;
        VeiculoId = veiculoId;
        GrupoAutomovelId = grupoAutomovelId;
        PlanoCobrancaId = planoCobrancaId;
        DataInicio = dataInicio;
        DataPrevistaTermino = dataPrevistaTermino;
        ValorPrevisto = valorPrevisto;
        Situacao = SituacaoAluguel.Aberto;
    }

    public void Editar(
        Guid clienteId,
        Guid condutorId,
        Guid veiculoId,
        Guid grupoAutomovelId,
        Guid planoCobrancaId,
        DateTime dataInicio,
        DateTime dataPrevistaTermino,
        decimal valorPrevisto)
    {
        ClienteId = clienteId;
        CondutorId = condutorId;
        VeiculoId = veiculoId;
        GrupoAutomovelId = grupoAutomovelId;
        PlanoCobrancaId = planoCobrancaId;
        DataInicio = dataInicio;
        DataPrevistaTermino = dataPrevistaTermino;
        ValorPrevisto = valorPrevisto;
    }

    public void MarcarComoEmAndamento()
    {
        Situacao = SituacaoAluguel.EmAndamento;
    }

    public void MarcarComoCancelado()
    {
        Situacao = SituacaoAluguel.Cancelado;
    }

    public void FecharAluguel(
        DateTime dataDevolucao,
        int kmFinal,
        decimal valorFinal,
        decimal valorMultas)
    {
        DataDevolucao = dataDevolucao;
        KmFinal = kmFinal;
        ValorFinal = valorFinal;
        ValorMultas = valorMultas;
        Situacao = SituacaoAluguel.Fechado;
    }
}
