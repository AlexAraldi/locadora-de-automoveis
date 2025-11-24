using FluentValidation;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.Editar;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Validators;

public class EditarTaxaServicoValidator : AbstractValidator<EditarTaxaServicoRequest>
{
    public EditarTaxaServicoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("O ID da taxa é obrigatório.");

        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome da taxa é obrigatório.")
            .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Valor)
            .GreaterThan(0).WithMessage("O valor deve ser maior que zero.");

        RuleFor(x => x.TipoCalculo)
            .IsInEnum().WithMessage("O tipo de cálculo é inválido.");
    }
}
