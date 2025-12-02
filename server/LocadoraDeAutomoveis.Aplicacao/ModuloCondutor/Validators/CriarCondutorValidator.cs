using FluentValidation;
using LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Commands.Criar;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Validators;

public class CriarCondutorValidator : AbstractValidator<CriarCondutorRequest>
{
    public CriarCondutorValidator()
    {
        RuleFor(x => x.ClienteId)
            .NotEqual(Guid.Empty).WithMessage("ClienteId é obrigatório.");

        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Nome é obrigatório.")
            .MaximumLength(100);

        RuleFor(x => x.Cpf)
            .NotEmpty().WithMessage("CPF é obrigatório.")
            .Length(11, 14);

        RuleFor(x => x.Cnh)
            .NotEmpty().WithMessage("CNH é obrigatória.")
            .MaximumLength(20);

        RuleFor(x => x.ValidadeCnh)
            .GreaterThan(DateTime.Today).WithMessage("A CNH deve estar válida.");
    }
}
