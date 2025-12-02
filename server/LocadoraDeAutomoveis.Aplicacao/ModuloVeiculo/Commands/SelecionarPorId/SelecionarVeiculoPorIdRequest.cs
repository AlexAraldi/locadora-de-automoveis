using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.SelecionarPorId;

public class SelecionarVeiculoPorIdRequest : IRequest<object>
{
    public Guid Id { get; set; }
}
