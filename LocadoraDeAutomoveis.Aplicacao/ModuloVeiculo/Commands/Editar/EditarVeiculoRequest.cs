using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.Editar;

public class EditarVeiculoRequest : IRequest<object>
{
    public Guid Id { get; set; }

    public string Modelo { get; set; }
    public string Marca { get; set; }
    public int Ano { get; set; }
    public string Placa { get; set; }
    public decimal Quilometragem { get; set; }
    public int Combustivel { get; set; }
}
