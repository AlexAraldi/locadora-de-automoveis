using LocadoraDeAutomoveis.Dominio.ModuloVeiculo;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.Criar;

public class CriarVeiculoRequestHandler : IRequestHandler<CriarVeiculoRequest, object>
{
    private readonly IVeiculoRepository _repository;
    private readonly CriarVeiculoValidator _validator;

    public CriarVeiculoRequestHandler(IVeiculoRepository repository)
    {
        _repository = repository;
        _validator = new CriarVeiculoValidator();
    }

    public async Task<object> Handle(CriarVeiculoRequest request, CancellationToken cancellationToken)
    {
        var validation = _validator.Validate(request);

        if (!validation.IsValid)
            return validation.Errors.Select(e => e.ErrorMessage);

        // Verifica placa duplicada
        var existentes = await _repository.SelecionarTodosAsync();
        if (existentes.Any(x => x.Placa == request.Placa))
            return VeiculoErrorResults.PlacaJaRegistrada;

        var v = new Veiculo(
            request.Foto,
            request.Modelo,
            request.Marca,
            request.Ano,
            request.Placa,
            request.Quilometragem,
            (TipoCombustivel)request.Combustivel
        );

        await _repository.AdicionarAsync(v);

        return new
        {
            Mensagem = "Veículo registrado com sucesso.",
            Id = v.Id
        };
    }
}
