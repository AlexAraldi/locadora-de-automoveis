using LocadoraDeAutomoveis.Dominio.ModuloVeiculo;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.Excluir;

public class ExcluirVeiculoRequestHandler : IRequestHandler<ExcluirVeiculoRequest, object>
{
    private readonly IVeiculoRepository _repository;

    public ExcluirVeiculoRequestHandler(IVeiculoRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(ExcluirVeiculoRequest request, CancellationToken cancellationToken)
    {
        var veiculo = await _repository.SelecionarPorIdAsync(request.Id);

        if (veiculo == null)
            return VeiculoErrorResults.VeiculoNaoEncontrado;

        await _repository.ExcluirAsync(veiculo);

        return new { Mensagem = "Veículo excluído com sucesso." };
    }
}
