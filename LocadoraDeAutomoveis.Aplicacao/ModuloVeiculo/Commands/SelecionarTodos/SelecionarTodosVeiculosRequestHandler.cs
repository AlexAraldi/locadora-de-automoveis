using LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.DTOs;
using LocadoraDeAutomoveis.Dominio.ModuloVeiculo;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.SelecionarTodos;

public class SelecionarTodosVeiculosRequestHandler
{
    private readonly IVeiculoRepository _repository;

    public SelecionarTodosVeiculosRequestHandler(IVeiculoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<VeiculoDto>> Handle(SelecionarTodosVeiculosRequest request)
    {
        var lista = await _repository.SelecionarTodos();

        return lista.Select(v => new VeiculoDto
        {
            Id = v.Id,
            Modelo = v.Modelo,
            Marca = v.Marca,
            Ano = v.Ano,
            Placa = v.Placa,
            Quilometragem = v.Quilometragem,
            Combustivel = (int)v.Combustivel,
            Ativo = v.Ativo
        });
    }
}
