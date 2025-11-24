using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.Excluir;

public class ExcluirPlanoCobrancaRequestHandler
{
    private readonly IPlanoCobrancaRepository _repository;

    public ExcluirPlanoCobrancaRequestHandler(IPlanoCobrancaRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(ExcluirPlanoCobrancaRequest request)
    {
        var plano = await _repository.SelecionarPorIdAsync(request.Id);

        if (plano == null)
            return PlanoCobrancaErrorResults.PlanoNaoEncontrado;

        await _repository.ExcluirAsync(plano);

        return new { Mensagem = "Plano excluído com sucesso." };
    }
}
