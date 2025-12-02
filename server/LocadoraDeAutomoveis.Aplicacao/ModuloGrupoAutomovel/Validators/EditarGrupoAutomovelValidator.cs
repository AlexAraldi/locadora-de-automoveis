using FluentValidation;
using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.Editar;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Validators
{
    public class EditarGrupoAutomovelValidator : AbstractValidator<EditarGrupoAutomovelRequest>
    {
        public EditarGrupoAutomovelValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("Id inválido.");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("Máx 100 caracteres.");
        }
    }
}
