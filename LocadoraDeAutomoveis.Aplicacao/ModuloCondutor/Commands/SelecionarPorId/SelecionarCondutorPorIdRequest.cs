using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Commands.SelecionarPorId;

public class SelecionarCondutorPorIdRequest : IRequest<object>
{
    public Guid Id { get; set; }
}
