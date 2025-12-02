using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.Excluir;

public class ExcluirAluguelRequestHandler : IRequestHandler<ExcluirAluguelRequest, object>
{
    private readonly IAluguelRepository _repository;

    public ExcluirAluguelRequestHandler(IAluguelRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(ExcluirAluguelRequest request, CancellationToken cancellationToken)
    {
        var aluguel = await _repository.SelecionarPorIdAsync(request.Id);

        if (aluguel == null)
            return AluguelErrorResults.AluguelNaoEncontrado;

        await _repository.ExcluirAsync(aluguel);

        return new { Mensagem = "Aluguel excluído com sucesso." };
    }
}
