using LocadoraDeAutomoveis.Dominio.ModuloCondutor;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Commands.Excluir;

public class ExcluirCondutorRequestHandler
{
    private readonly ICondutorRepository _repository;

    public ExcluirCondutorRequestHandler(ICondutorRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(ExcluirCondutorRequest request)
    {
        var condutor = await _repository.SelecionarPorIdAsync(request.Id);
        if (condutor == null)
            return CondutorErrorResults.CondutorNaoEncontrado;

        await _repository.ExcluirAsync(condutor);

        return new { Mensagem = "Condutor excluído com sucesso." };
    }
}
