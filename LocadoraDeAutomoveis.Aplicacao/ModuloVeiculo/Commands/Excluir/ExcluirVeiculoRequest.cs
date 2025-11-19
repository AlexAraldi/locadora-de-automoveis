using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.Excluir;

public class ExcluirVeiculoRequest : IRequest<object>
{
    public Guid Id { get; set; }
}
