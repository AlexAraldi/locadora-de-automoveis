using LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.DTOs;
using LocadoraDeAutomoveis.Dominio.ModuloVeiculo;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.SelecionarPorId;

public class SelecionarVeiculoPorIdHandler
{
    private readonly IVeiculoRepository _repository;

    public SelecionarVeiculoPorIdHandler(IVeiculoRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(SelecionarVeiculoPorIdRequest request)
    {
        var v = await _repository.SelecionarPorId(request.Id);

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
