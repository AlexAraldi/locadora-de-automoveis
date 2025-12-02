using FluentValidation;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Validators;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.Editar;

public class EditarPlanoCobrancaRequestHandler : IRequestHandler<EditarPlanoCobrancaRequest,object>
{
    private readonly IPlanoCobrancaRepository _repository;
    private readonly IGrupoAutomovelRepository _grupoRepository;
    private readonly EditarPlanoCobrancaValidator _validator;

    public EditarPlanoCobrancaRequestHandler(
        IPlanoCobrancaRepository repository,
        IGrupoAutomovelRepository grupoRepository)
    {
        _repository = repository;
        _grupoRepository = grupoRepository;
        _validator = new EditarPlanoCobrancaValidator();
    }

    public async Task<object> Handle(EditarPlanoCobrancaRequest request, CancellationToken cancellationToken)
    {
        var validation = _validator.Validate(request);
        if (!validation.IsValid)
            return validation.Errors.Select(x => x.ErrorMessage);

        var plano = await _repository.SelecionarPorIdAsync(request.Id);
        if (plano == null)
            return PlanoCobrancaErrorResults.PlanoNaoEncontrado;

        var grupo = await _grupoRepository.SelecionarPorIdAsync(request.GrupoAutomovelId);
        if (grupo == null)
            return PlanoCobrancaErrorResults.GrupoNaoEncontrado;

        var duplicado = await _repository.BuscarDuplicadoAsync(request.GrupoAutomovelId, request.TipoPlano);
        if (duplicado != null && duplicado.Id != request.Id)
            return PlanoCobrancaErrorResults.PlanoDuplicado;

        plano.Editar(
            request.GrupoAutomovelId,
            request.TipoPlano,
            request.ValorDiaria,
            request.ValorPorKm,
            request.KmLivre,
            request.KmControladoLimite,
            request.ValorExcedenteKm
        );

        await _repository.AtualizarAsync(plano);

        return new { Mensagem = "Plano atualizado com sucesso." };
    }
}
