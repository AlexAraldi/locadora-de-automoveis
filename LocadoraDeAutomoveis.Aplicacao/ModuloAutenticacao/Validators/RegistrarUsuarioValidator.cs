using FluentValidation;
using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Commands.Registrar;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Validators
{
    public class RegistrarUsuarioValidator : AbstractValidator<RegistrarUsuarioRequest>
    {
        public RegistrarUsuarioValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("Email inválido.")
                .MaximumLength(100);

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("A senha é obrigatória.")
                .MinimumLength(6).WithMessage("A senha deve ter pelo menos 6 caracteres.");
        }
    }
}
