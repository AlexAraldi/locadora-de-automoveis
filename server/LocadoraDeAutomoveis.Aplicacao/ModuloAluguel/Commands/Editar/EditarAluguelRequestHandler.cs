using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Validators;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.Editar;

public class EditarAluguelRequestHandler : IRequestHandler<EditarAluguelRequest, object>
{
    private readonly IAluguelRepository _repository;
    private readonly EditarAluguelValidator _validator;

    public EditarAluguelRequestHandler(IAluguelRepository repository)
    {
        _repository = repository;
        _validator = new EditarAluguelValidator();
    }

    public async Task<object> Handle(EditarAluguelRequest request, CancellationToken cancellationToken)
    {
        var validation = _validator.Validate(request);
        if (!validation.IsValid)
            return validation.Errors.Select(x => x.ErrorMessage);

        var aluguel = await _repository.SelecionarPorIdAsync(request.Id);
        if (aluguel == null)
            return AluguelErrorResults.AluguelNaoEncontrado;

        aluguel.Editar(
            request.ClienteId,
            request.CondutorId,
            request.VeiculoId,
            request.GrupoAutomovelId,
            request.PlanoCobrancaId,
            request.DataInicio,
            request.DataPrevistaTermino,
            aluguel.ValorPrevisto
        );

        await _repository.AtualizarAsync(aluguel);

        return new { Mensagem = "Aluguel atualizado com sucesso." };
    }
}
