using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.Excluir;

public class ExcluirAluguelRequest : IRequest<object>
{
    public Guid Id { get; set; }
}
