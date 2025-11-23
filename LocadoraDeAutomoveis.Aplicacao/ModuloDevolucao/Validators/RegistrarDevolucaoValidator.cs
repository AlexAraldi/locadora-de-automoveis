using FluentValidation;
using LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.Commands.Registrar;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.Validators
{
    public class RegistrarDevolucaoValidator : AbstractValidator<RegistrarDevolucaoRequest>
    {
        public RegistrarDevolucaoValidator()
        {
            RuleFor(x => x.AluguelId).NotEmpty();
            RuleFor(x => x.DataDevolucao).NotEmpty();
            RuleFor(x => x.KmFinal).GreaterThan(0);
        }
    }
}
