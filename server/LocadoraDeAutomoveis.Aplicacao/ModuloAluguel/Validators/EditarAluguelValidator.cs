using FluentValidation;
using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.Editar;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Validators;

public class EditarAluguelValidator : AbstractValidator<EditarAluguelRequest>
{
    public EditarAluguelValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty).WithMessage("Id é obrigatório.");

        

    }
}
