using FluentValidation;
using LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracao.Commands.Editar;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracao.Validators;

public class EditarConfiguracaoValidator : AbstractValidator<EditarConfiguracaoRequest>
{
    public EditarConfiguracaoValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Id é obrigatório.");

        RuleFor(x => x.PrecoGasolina)
            .GreaterThanOrEqualTo(0).WithMessage("Preço da gasolina inválido.");

        RuleFor(x => x.PrecoGas)
            .GreaterThanOrEqualTo(0).WithMessage("Preço do gás inválido.");

        RuleFor(x => x.PrecoDiesel)
            .GreaterThanOrEqualTo(0).WithMessage("Preço do diesel inválido.");

        RuleFor(x => x.PrecoAlcool)
            .GreaterThanOrEqualTo(0).WithMessage("Preço do álcool inválido.");
    }
}
