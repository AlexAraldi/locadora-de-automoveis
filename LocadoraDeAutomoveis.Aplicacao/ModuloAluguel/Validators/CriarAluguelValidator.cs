using FluentValidation;
using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.Criar;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Validators;

public class CriarAluguelValidator : AbstractValidator<CriarAluguelRequest>
{
    public CriarAluguelValidator()
    {
        RuleFor(x => x.ClienteId)
            .NotEqual(Guid.Empty).WithMessage("ClienteId é obrigatório.");

        RuleFor(x => x.CondutorId)
            .NotEqual(Guid.Empty).WithMessage("CondutorId é obrigatório.");

        RuleFor(x => x.VeiculoId)
            .NotEqual(Guid.Empty).WithMessage("VeiculoId é obrigatório.");

        RuleFor(x => x.GrupoAutomovelId)
            .NotEqual(Guid.Empty).WithMessage("GrupoAutomovelId é obrigatório.");

        RuleFor(x => x.PlanoCobrancaId)
            .NotEqual(Guid.Empty).WithMessage("PlanoCobrancaId é obrigatório.");

        RuleFor(x => x.DataPrevistaTermino)
            .GreaterThan(x => x.DataInicio)
            .WithMessage("Data prevista deve ser maior que a data de início.");
    }
}
