using FluentValidation;
using LocadoraDeAutomoveis.Aplicacao.ModuloCliente.Commands.Editar;

public class EditarClienteValidator : AbstractValidator<EditarClienteRequest>
{
    public EditarClienteValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Nome).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Telefone).NotEmpty();
    }
}
