using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.DTOs;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Commands.SelecionarTodos;

public class SelecionarTodosCondutoresRequestHandler : IRequestHandler<SelecionarTodosCondutoresRequest,IEnumerable<CondutorDto>>
{
    private readonly ICondutorRepository _repository;

    public SelecionarTodosCondutoresRequestHandler(ICondutorRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CondutorDto>> Handle(SelecionarTodosCondutoresRequest request, CancellationToken cancellationToken)
    {
        var lista = await _repository.SelecionarTodosAsync();

        return lista.Select(c => new CondutorDto
        {
            Id = c.Id,
            ClienteId = c.ClienteId,
            Nome = c.Nome,
            Cpf = c.Cpf,
            Cnh = c.Cnh,
            ValidadeCnh = c.ValidadeCnh,
            Telefone = c.Telefone,
            Email = c.Email,
            Endereco = c.Endereco,
            CondutorPrincipal = c.CondutorPrincipal
        });
    }
}
