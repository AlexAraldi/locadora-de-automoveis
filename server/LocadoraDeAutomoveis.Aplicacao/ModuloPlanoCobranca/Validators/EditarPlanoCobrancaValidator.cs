using FluentValidation;
using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.Editar;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Validators;

public class EditarPlanoCobrancaValidator : AbstractValidator<EditarPlanoCobrancaRequest>
{
    public EditarPlanoCobrancaValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty).WithMessage("Id é obrigatório.");

        RuleFor(x => x.GrupoAutomovelId)
            .NotEqual(Guid.Empty).WithMessage("GrupoAutomovelId é obrigatório.");

        RuleFor(x => x.TipoPlano)
            .IsInEnum().WithMessage("Tipo de plano inválido.");

        RuleFor(x => x.ValorDiaria)
            .GreaterThan(0).WithMessage("Valor da diária deve ser maior que zero.");

        When(x => x.TipoPlano == TipoPlano.Diario, () =>
        {
            RuleFor(x => x.ValorPorKm)
                .NotNull().WithMessage("ValorPorKm é obrigatório no Plano Diário.");
        });

        When(x => x.TipoPlano == TipoPlano.KmLivre, () =>
        {
            RuleFor(x => x.KmLivre)
                .NotNull().WithMessage("KmLivre é obrigatório no Plano KM Livre.");
        });

        When(x => x.TipoPlano == TipoPlano.KmControlado, () =>
        {
            RuleFor(x => x.KmControladoLimite)
                .NotNull().WithMessage("KmControladoLimite é obrigatório.");

            RuleFor(x => x.ValorExcedenteKm)
                .NotNull().WithMessage("ValorExcedenteKm é obrigatório.");
        });
    }
}
