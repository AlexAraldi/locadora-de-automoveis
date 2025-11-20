using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.DTOs;
using LocadoraDeAutomoveis.Dominio.ModuloAluguel;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.SelecionarPorId;

public class SelecionarAluguelPorIdRequestHandler
{
    private readonly IAluguelRepository _repository;

    public SelecionarAluguelPorIdRequestHandler(IAluguelRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(SelecionarAluguelPorIdRequest request)
    {
        var aluguel = await _repository.BuscarPorId(request.Id);

        if (aluguel == null)
            return AluguelErrorResults.AluguelNaoEncontrado;

        return new AluguelDto
        {
            Id = aluguel.Id,
            ClienteId = aluguel.ClienteId,
            CondutorId = aluguel.CondutorId,
            VeiculoId = aluguel.VeiculoId,
            GrupoAutomovelId = aluguel.GrupoAutomovelId,
            PlanoCobrancaId = aluguel.PlanoCobrancaId,
            DataInicio = aluguel.DataInicio,
            DataPrevistaTermino = aluguel.DataPrevistaTermino,
            ValorPrevisto = aluguel.ValorPrevisto,
            Situacao = aluguel.Situacao.ToString(),
            KmFinal = aluguel.KmFinal,
            ValorFinal = aluguel.ValorFinal,
            ValorMultas = aluguel.ValorMultas
        };
    }
}
