using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.Criar;

public class CriarAluguelRequest : IRequest<object>
{
    public Guid ClienteId { get; set; }
    public Guid CondutorId { get; set; }
    public Guid VeiculoId { get; set; }
    public Guid GrupoAutomovelId { get; set; }
    public Guid PlanoCobrancaId { get; set; }

    public DateTime DataInicio { get; set; }
    public DateTime DataPrevistaTermino { get; set; }
}
