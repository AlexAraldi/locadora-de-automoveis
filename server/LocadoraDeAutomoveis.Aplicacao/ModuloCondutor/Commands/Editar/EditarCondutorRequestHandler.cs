using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Validators;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Commands.Editar;

public class EditarCondutorRequestHandler : IRequestHandler<EditarCondutorRequest, object>
{
    private readonly ICondutorRepository _repository;
    private readonly IClienteRepository _clienteRepository;
    private readonly EditarCondutorValidator _validator;

    public EditarCondutorRequestHandler(
        ICondutorRepository repository,
        IClienteRepository clienteRepository)
    {
        _repository = repository;
        _clienteRepository = clienteRepository;
        _validator = new EditarCondutorValidator();
    }

    public async Task<object> Handle(EditarCondutorRequest request, CancellationToken cancellationToken)
    {
        var validation = _validator.Validate(request);
        if (!validation.IsValid)
            return validation.Errors.Select(e => e.ErrorMessage);

        var condutor = await _repository.SelecionarPorIdAsync(request.Id);
        if (condutor == null)
            return CondutorErrorResults.CondutorNaoEncontrado;

        var cliente = await _clienteRepository.SelecionarPorIdAsync(request.ClienteId);
        if (cliente == null)
            return CondutorErrorResults.ClienteNaoEncontrado;

        var cpfDuplicado = await _repository.BuscarPorCpfAsync(request.Cpf);
        if (cpfDuplicado != null && cpfDuplicado.Id != request.Id)
            return CondutorErrorResults.CpfDuplicado;

        condutor.Editar(
            request.ClienteId,
            request.Nome,
            request.Cpf,
            request.Cnh,
            request.ValidadeCnh,
            request.Telefone,
            request.Email,
            request.Endereco,
            request.CondutorPrincipal
        );

        await _repository.AtualizarAsync(condutor);

        return new
        {
            Mensagem = "Condutor atualizado com sucesso.",
            Id = condutor.Id
        };
    }
}
