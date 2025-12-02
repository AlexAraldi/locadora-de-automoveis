using LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.DTOs;
using LocadoraDeAutomoveis.Dominio.ModuloDevolucao;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.Commands.SelecionarTodos
{
    public class SelecionarTodasDevolucoesRequestHandler : IRequestHandler<SelecionarTodasDevolucoesRequest,IEnumerable<DevolucaoDto>>
    {
        private readonly IDevolucaoRepository _repository;

        public SelecionarTodasDevolucoesRequestHandler(IDevolucaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DevolucaoDto>> Handle(SelecionarTodasDevolucoesRequest request, CancellationToken cancellationToken)
        {
            var lista = await _repository.SelecionarTodosAsync();

            return lista.Select(d => new DevolucaoDto
            {
                Id = d.Id,
                AluguelId = d.AluguelId,
                DataDevolucao = d.DataDevolucao,
                KmFinal = d.KmFinal,
                NivelTanque = d.NivelTanque.ToString(),
                ValorCombustivel = d.ValorCombustivel,
                ValorKmExcedente = d.ValorKmExcedente,
                ValorMultas = d.ValorMultas,
                ValorFinal = d.ValorFinal
            });
        }
    }
}
