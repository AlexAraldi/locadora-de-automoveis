using LocadoraDeAutomoveis.Dominio.ModuloAluguel;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.Excluir;

public class ExcluirAluguelRequestHandler
{
    private readonly IAluguelRepository _repository;

    public ExcluirAluguelRequestHandler(IAluguelRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(ExcluirAluguelRequest request)
    {
        var aluguel = await _repository.SelecionarPorId(request.Id);

        if (aluguel == null)
            return AluguelErrorResults.AluguelNaoEncontrado;

        await _repository.Excluir(aluguel);

        return new { Mensagem = "Aluguel excluído com sucesso." };
    }
}
