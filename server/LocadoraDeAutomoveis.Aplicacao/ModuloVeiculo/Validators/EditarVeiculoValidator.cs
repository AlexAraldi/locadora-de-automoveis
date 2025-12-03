using FluentValidation;
using LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.Editar;

public class EditarVeiculoValidator : AbstractValidator<EditarVeiculoRequest>
{
    public EditarVeiculoValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(c => c.Foto).NotEmpty();
        RuleFor(x => x.Modelo).NotEmpty();
        RuleFor(x => x.Marca).NotEmpty();
        RuleFor(x => x.Placa).NotEmpty();
        RuleFor(x => x.Ano).GreaterThan(1980);
        RuleFor(x => x.Quilometragem).GreaterThanOrEqualTo(0);
    }
}
