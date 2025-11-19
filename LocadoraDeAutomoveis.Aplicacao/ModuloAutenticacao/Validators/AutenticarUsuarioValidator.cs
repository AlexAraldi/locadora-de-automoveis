using FluentValidation;
using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Commands.Autenticar;

namespace LocadoraDeVeiculos.Aplicacao.ModuloAutenticacao.Commands.Autenticar
{
    public class AutenticarUsuarioValidator : AbstractValidator<AutenticarUsuarioRequest>
    {
        public AutenticarUsuarioValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("E-mail inválido.");

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("A senha é obrigatória.");
        }
    }
}
