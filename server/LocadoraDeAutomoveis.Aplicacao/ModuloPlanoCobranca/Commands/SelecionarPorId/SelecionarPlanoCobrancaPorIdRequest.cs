using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.SelecionarPorId;

public class SelecionarPlanoCobrancaPorIdRequest : IRequest<object>
{
    public Guid Id { get; set; }
}
