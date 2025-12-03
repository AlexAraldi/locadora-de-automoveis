using LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.DTOs;
using LocadoraDeAutomoveis.Dominio.ModuloVeiculo;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.SelecionarTodos;

public class SelecionarTodosVeiculosRequestHandler : IRequestHandler<SelecionarTodosVeiculosRequest,IEnumerable<VeiculoDto>>
{
    private readonly IVeiculoRepository _repository;

    public SelecionarTodosVeiculosRequestHandler(IVeiculoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<VeiculoDto>> Handle(SelecionarTodosVeiculosRequest request, CancellationToken cancellationToken)
    {
        var lista = await _repository.SelecionarTodosAsync();

        return lista.Select(v => new VeiculoDto
        {
            Id = v.Id,
            Foto = v.Foto,
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
