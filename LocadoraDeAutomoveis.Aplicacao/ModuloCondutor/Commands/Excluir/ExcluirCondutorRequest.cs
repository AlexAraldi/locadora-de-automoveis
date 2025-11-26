using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Commands.Excluir;

public class ExcluirCondutorRequest : IRequest<object>
{
    public Guid Id { get; set; }
}
