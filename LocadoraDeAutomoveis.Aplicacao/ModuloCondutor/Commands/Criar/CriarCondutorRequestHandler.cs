using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Validators;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Commands.Criar;

public class CriarCondutorRequestHandler : IRequestHandler<CriarCondutorRequest,object>
{
    private readonly ICondutorRepository _repository;
    private readonly IClienteRepository _clienteRepository;
    private readonly CriarCondutorValidator _validator;

    public CriarCondutorRequestHandler(
        ICondutorRepository repository,
        IClienteRepository clienteRepository)
    {
        _repository = repository;
        _clienteRepository = clienteRepository;
        _validator = new CriarCondutorValidator();
    }

    public async Task<object> Handle(CriarCondutorRequest request, CancellationToken cancellationToken)
    {
        var validation = _validator.Validate(request);
        if (!validation.IsValid)
            return validation.Errors.Select(e => e.ErrorMessage);

        var cliente = await _clienteRepository.SelecionarPorIdAsync(request.ClienteId);
        if (cliente == null)
            return CondutorErrorResults.ClienteNaoEncontrado;

        var duplicado = await _repository.BuscarPorCpfAsync(request.Cpf);
        if (duplicado != null)
            return CondutorErrorResults.CpfDuplicado;

        var condutor = new Condutor(
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

        await _repository.AdicionarAsync(condutor);

        return new
        {
            Mensagem = "Condutor criado com sucesso.",
            Id = condutor.Id
        };
    }
}
