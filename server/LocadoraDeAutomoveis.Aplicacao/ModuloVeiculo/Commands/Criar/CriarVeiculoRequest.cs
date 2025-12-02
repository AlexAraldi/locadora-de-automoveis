using LocadoraDeAutomoveis.Dominio.ModuloVeiculo;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.Criar;

public class CriarVeiculoRequest : IRequest<object>
{
    public string? Modelo { get; set; }
    public string? Marca { get; set; }
    public int Ano { get; set; }
    public string? Placa { get; set; }
    public decimal Quilometragem { get; set; }
    public TipoCombustivel Combustivel { get; set; }
}
