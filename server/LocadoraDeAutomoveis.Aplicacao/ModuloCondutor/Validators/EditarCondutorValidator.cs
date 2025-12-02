using FluentValidation;
using LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Commands.Editar;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Validators;

public class EditarCondutorValidator : AbstractValidator<EditarCondutorRequest>
{
    public EditarCondutorValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty).WithMessage("Id é obrigatório.");

        RuleFor(x => x.ClienteId)
            .NotEqual(Guid.Empty).WithMessage("ClienteId é obrigatório.");

        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Nome é obrigatório.");

        RuleFor(x => x.Cpf)
            .NotEmpty().WithMessage("CPF é obrigatório.");

        RuleFor(x => x.Cnh)
            .NotEmpty().WithMessage("CNH é obrigatória.");

        RuleFor(x => x.ValidadeCnh)
            .GreaterThan(DateTime.Today).WithMessage("CNH vencida.");
    }
}
