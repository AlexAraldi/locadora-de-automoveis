using LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.DTOs;
using LocadoraDeAutomoveis.Dominio.ModuloVeiculo;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.SelecionarPorId;

public class SelecionarVeiculoPorIdRequestHandler : IRequestHandler<SelecionarVeiculoPorIdRequest, object>
{

    private readonly IVeiculoRepository _repository;

    public SelecionarVeiculoPorIdRequestHandler(IVeiculoRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(SelecionarVeiculoPorIdRequest request, CancellationToken cancellationToken)
    {
        var v = await _repository.SelecionarPorIdAsync(request.Id);

        if (v == null)
            return VeiculoErrorResults.VeiculoNaoEncontrado;

        return new VeiculoDto
        {
            Id = v.Id,
            Modelo = v.Modelo,
            Marca = v.Marca,
            Ano = v.Ano,
            Placa = v.Placa,
            Quilometragem = v.Quilometragem,
            Combustivel = (int)v.Combustivel,
            Ativo = v.Ativo
        };
    }
}
