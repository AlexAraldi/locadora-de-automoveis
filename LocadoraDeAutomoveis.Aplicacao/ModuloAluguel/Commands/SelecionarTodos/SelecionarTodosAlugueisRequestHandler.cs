using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.DTOs;
using LocadoraDeAutomoveis.Dominio.ModuloAluguel;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.SelecionarTodos;

public class SelecionarTodosAlugueisRequestHandler
{
    private readonly IAluguelRepository _repository;

    public SelecionarTodosAlugueisRequestHandler(IAluguelRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AluguelDto>> Handle(SelecionarTodosAlugueisRequest request)
    {
        var alugueis = await _repository.SelecionarTodosAsync();

        return alugueis.Select(a => new AluguelDto
        {
            Id = a.Id,
            ClienteId = a.ClienteId,
            CondutorId = a.CondutorId,
            VeiculoId = a.VeiculoId,
            GrupoAutomovelId = a.GrupoAutomovelId,
            PlanoCobrancaId = a.PlanoCobrancaId,
            DataInicio = a.DataInicio,
            DataPrevistaTermino = a.DataPrevistaTermino,
            ValorPrevisto = a.ValorPrevisto,
            Situacao = a.Situacao.ToString()
        });
    }
}
