using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracao.Commands.Editar;

public class EditarConfiguracaoRequest : IRequest<object>
{
    public Guid Id { get; set; }
    public decimal PrecoGasolina { get; set; }
    public decimal PrecoGas { get; set; }
    public decimal PrecoDiesel { get; set; }
    public decimal PrecoAlcool { get; set; }
}
