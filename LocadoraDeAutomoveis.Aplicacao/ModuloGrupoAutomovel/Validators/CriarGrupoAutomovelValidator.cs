using FluentValidation;
using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.Criar;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Validators
{
    public class CriarGrupoAutomovelValidator : AbstractValidator<CriarGrupoAutomovelRequest>
    {
        public CriarGrupoAutomovelValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("Máx 100 caracteres.");
        }
    }
}
