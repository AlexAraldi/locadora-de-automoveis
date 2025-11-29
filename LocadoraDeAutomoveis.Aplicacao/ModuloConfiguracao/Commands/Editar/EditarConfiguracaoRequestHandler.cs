using LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracao.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracao.Erros;
using LocadoraDeAutomoveis.Dominio.ModuloConfiguracao;
using MediatR;
using LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracao.Validator;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCliente.Commands.Editar;

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
            return validation.Errors.Select(x => x.ErrorMessage);

        var configuracao = await _repository.SelecionarAsync(request.Id);
        if (configuracao == null)
            return ConfiguracaoErrorResults.ConfiguracaoNaoEncontrada;

        configuracao.Editar(
            request.PrecoAlcool,
            request.PrecoGasolina,
            request.PrecoDiesel,
            request.PrecoGas       
        );
        await _repository.EditarAsync(configuracao);

        return new { Mensagem = "Preço atualizado com sucesso." };
    }



}

