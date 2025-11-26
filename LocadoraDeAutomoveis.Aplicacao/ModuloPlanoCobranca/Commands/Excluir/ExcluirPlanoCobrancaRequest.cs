using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.Excluir;

public class ExcluirPlanoCobrancaRequest : IRequest<object>
{
    public Guid Id { get; set; }
}
