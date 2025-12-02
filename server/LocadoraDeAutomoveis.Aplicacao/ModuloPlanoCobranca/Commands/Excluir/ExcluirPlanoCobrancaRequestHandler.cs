using LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.Excluir;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.Excluir;

public class ExcluirPlanoCobrancaRequestHandler : IRequestHandler<ExcluirPlanoCobrancaRequest, object>
{
    private readonly IPlanoCobrancaRepository _repository;

    public ExcluirPlanoCobrancaRequestHandler(IPlanoCobrancaRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(ExcluirPlanoCobrancaRequest request, CancellationToken cancellationToken)
    {
        var plano = await _repository.SelecionarPorIdAsync(request.Id);

        if (plano == null)
            return PlanoCobrancaErrorResults.PlanoNaoEncontrado;

        await _repository.ExcluirAsync(plano);

        return new { Mensagem = "Plano excluído com sucesso." };
    }
}
