using LocadoraDeAutomoveis.Dominio.ModuloVeiculo;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.Editar;

public class EditarVeiculoRequestHandler : IRequestHandler<EditarVeiculoRequest, object>
{
    private readonly IVeiculoRepository _repository;
    private readonly EditarVeiculoValidator _validator;

    public EditarVeiculoRequestHandler(IVeiculoRepository repository)
    {
        _repository = repository;
        _validator = new EditarVeiculoValidator();
    }

    public async Task<object> Handle(EditarVeiculoRequest request, CancellationToken cancellationToken)
    {
        var validation = _validator.Validate(request);
        if (!validation.IsValid)
            return validation.Errors.Select(x => x.ErrorMessage);

        var veiculo = await _repository.SelecionarPorId(request.Id);

        if (veiculo == null)
            return VeiculoErrorResults.VeiculoNaoEncontrado;

        // Verifica placa duplicada
        var todos = await _repository.SelecionarTodos();
        if (todos.Any(x => x.Placa == request.Placa && x.Id != request.Id))
            return VeiculoErrorResults.PlacaJaRegistrada;

        veiculo.Editar(
            request.Modelo,
            request.Marca,
            request.Ano,
            request.Placa,
            request.Quilometragem,
            (TipoCombustivel)request.Combustivel
        );

        await _repository.Editar(veiculo);

        return new { Mensagem = "Veículo atualizado com sucesso." };
    }
}
