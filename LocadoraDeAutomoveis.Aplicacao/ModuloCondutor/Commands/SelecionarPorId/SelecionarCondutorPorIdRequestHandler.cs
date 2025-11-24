using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.DTOs;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Commands.SelecionarPorId;

public class SelecionarCondutorPorIdRequestHandler
{
    private readonly ICondutorRepository _repository;

    public SelecionarCondutorPorIdRequestHandler(ICondutorRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(SelecionarCondutorPorIdRequest request)
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
