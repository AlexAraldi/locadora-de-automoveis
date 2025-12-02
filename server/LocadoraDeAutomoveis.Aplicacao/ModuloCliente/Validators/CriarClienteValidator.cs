using FluentValidation;
using LocadoraDeAutomoveis.Aplicacao.ModuloCliente.Commands.Criar;

public class CriarClienteValidator : AbstractValidator<CriarClienteRequest>
{
    public CriarClienteValidator()
    {
        RuleFor(x => x.Nome).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Telefone).NotEmpty();
    }
}
