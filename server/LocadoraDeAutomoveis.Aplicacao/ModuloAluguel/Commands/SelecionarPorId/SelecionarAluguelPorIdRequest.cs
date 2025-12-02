using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.SelecionarPorId;

public class SelecionarAluguelPorIdRequest : IRequest<object>
{
    public Guid Id { get; set; }
}
