using LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.DTOs;
using LocadoraDeAutomoveis.Dominio.ModuloDevolucao;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.Commands.SelecionarPorId
{
    public class SelecionarDevolucaoPorIdRequestHandler
    {
        private readonly IDevolucaoRepository _repository;

        public SelecionarDevolucaoPorIdRequestHandler(IDevolucaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> Handle(SelecionarDevolucaoPorIdRequest request)
        {
            var d = await _repository.SelecionarPorIdAsync(request.Id);

            if (d == null)
                return "Devolução não encontrada.";

            return new DevolucaoDto
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
            };
        }
    }
}
