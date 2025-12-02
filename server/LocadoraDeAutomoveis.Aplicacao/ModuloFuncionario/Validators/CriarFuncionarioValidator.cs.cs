using FluentValidation;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.Criar;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Validators
{
    public class CriarFuncionarioValidator : AbstractValidator<CriarFuncionarioRequest>
    {
        public CriarFuncionarioValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("Formato de e-mail inválido.");

            RuleFor(x => x.Cargo)
                .NotEmpty().WithMessage("O cargo é obrigatório.");

            RuleFor(x => x.Salario)
                .GreaterThan(0).WithMessage("O salário deve ser maior que zero.");
        }
    }
}
