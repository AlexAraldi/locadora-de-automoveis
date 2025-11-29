using FluentValidation;
using LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracao.Commands.Editar;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracao.Validator
{
    public class EditarConfiguracaoValidator : AbstractValidator<EditarConfiguracaoRequest>
    {
        public EditarConfiguracaoValidator()
        {
            RuleFor(x => x.Id)
            .NotEqual(Guid.Empty).WithMessage("Id é obrigatório.");
        }
    }
}
