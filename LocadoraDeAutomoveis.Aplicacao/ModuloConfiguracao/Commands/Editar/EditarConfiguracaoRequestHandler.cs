using LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracao.Validators;
using LocadoraDeAutomoveis.Dominio.ModuloConfiguracao;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracao.Commands.Editar;

public class EditarConfiguracaoRequestHandler : IRequestHandler<EditarConfiguracaoRequest, object>
{
    private readonly IConfiguracaoRepository _repository;
    private readonly EditarConfiguracaoValidator _validator;

    public EditarConfiguracaoRequestHandler(IConfiguracaoRepository repository)
    {
        _repository = repository;
        _validator = new EditarConfiguracaoValidator();
    }

    public async Task<object> Handle(EditarConfiguracaoRequest request, CancellationToken cancellationToken)
    {
        var validation = _validator.Validate(request);
        if (!validation.IsValid)
            return validation.Errors.Select(e => e.ErrorMessage);

        var existente = await _repository.SelecionarAsync();
        if (existente == null)
            return ConfiguracaoErrorResults.ConfiguracaoNaoEncontrada;

        existente.Editar(
            request.PrecoGasolina,
            request.PrecoGas,
            request.PrecoAlcool,
            request.PrecoDiesel
        );

        await _repository.EditarAsync(existente);

        return new
        {
            Mensagem = "Configuração atualizada com sucesso.",
            Id = existente.Id
        };
    }
}
