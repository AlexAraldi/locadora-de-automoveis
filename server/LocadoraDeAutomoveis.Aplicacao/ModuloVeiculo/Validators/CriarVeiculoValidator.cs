using FluentValidation;
using LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.Criar;

public class CriarVeiculoValidator : AbstractValidator<CriarVeiculoRequest>
{
    public CriarVeiculoValidator()
    {
        RuleFor(x => x.Modelo).NotEmpty();
        RuleFor(x => x.Marca).NotEmpty();
        RuleFor(x => x.Placa).NotEmpty();
        RuleFor(x => x.Ano).GreaterThan(1980);
        RuleFor(x => x.Quilometragem).GreaterThanOrEqualTo(0);
    }
}
