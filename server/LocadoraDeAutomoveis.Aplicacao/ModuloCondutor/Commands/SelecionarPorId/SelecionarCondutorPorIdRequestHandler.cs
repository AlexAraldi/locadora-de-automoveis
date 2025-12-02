using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.DTOs;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Commands.SelecionarPorId;

public class SelecionarCondutorPorIdRequestHandler : IRequestHandler<SelecionarCondutorPorIdRequest,object>
{
    private readonly ICondutorRepository _repository;

    public SelecionarCondutorPorIdRequestHandler(ICondutorRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(SelecionarCondutorPorIdRequest request, CancellationToken cancellationToken)
    {
        var condutor = await _repository.SelecionarPorIdAsync(request.Id);

        if (condutor == null)
            return CondutorErrorResults.CondutorNaoEncontrado;

        return new CondutorDto
        {
            Id = condutor.Id,
            ClienteId = condutor.ClienteId,
            Nome = condutor.Nome,
            Cpf = condutor.Cpf,
            Cnh = condutor.Cnh,
            ValidadeCnh = condutor.ValidadeCnh,
            Telefone = condutor.Telefone,
            Email = condutor.Email,
            Endereco = condutor.Endereco,
            CondutorPrincipal = condutor.CondutorPrincipal
        };
    }
}
