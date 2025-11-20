using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomovel;
using FluentValidation;
using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Validators;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.Criar;

public class CriarPlanoCobrancaRequestHandler
{
    private readonly IPlanoCobrancaRepository _repository;
    private readonly IGrupoAutomovelRepository _grupoRepository;
    private readonly CriarPlanoCobrancaValidator _validator;

    public CriarPlanoCobrancaRequestHandler(
        IPlanoCobrancaRepository repository,
        IGrupoAutomovelRepository grupoRepository)
    {
        _repository = repository;
        _grupoRepository = grupoRepository;
        _validator = new CriarPlanoCobrancaValidator();
    }

    public async Task<object> Handle(CriarPlanoCobrancaRequest request)
    {
        var validation = _validator.Validate(request);
        if (!validation.IsValid)
            return validation.Errors.Select(x => x.ErrorMessage);

        var grupo = await _grupoRepository.BuscarPorId(request.GrupoAutomovelId);
        if (grupo == null)
            return PlanoCobrancaErrorResults.GrupoNaoEncontrado;

        var duplicado = await _repository.BuscarDuplicado(request.GrupoAutomovelId, request.TipoPlano);
        if (duplicado != null)
            return PlanoCobrancaErrorResults.PlanoDuplicado;

        var plano = new PlanoCobranca(
            request.GrupoAutomovelId,
            request.TipoPlano,
            request.ValorDiaria,
            request.ValorPorKm,
            request.KmLivre,
            request.KmControladoLimite,
            request.ValorExcedenteKm
        );

        await _repository.Adicionar(plano);

        return new { Mensagem = "Plano criado com sucesso.", plano.Id };
    }
}
