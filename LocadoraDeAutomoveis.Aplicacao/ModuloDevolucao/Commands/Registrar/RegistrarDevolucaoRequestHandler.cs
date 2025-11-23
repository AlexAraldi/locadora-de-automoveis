using LocadoraDeAutomoveis.Dominio.ModuloDevolucao;
using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Dominio.ModuloVeiculo;
using LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.DTOs;
using LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.Validators;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.Commands.Registrar
{
    public class RegistrarDevolucaoRequestHandler
    {
        private readonly IDevolucaoRepository _devolucaoRepository;
        private readonly IAluguelRepository _aluguelRepository;
        private readonly IVeiculoRepository _veiculoRepository;

        private readonly RegistrarDevolucaoValidator _validator;

        public RegistrarDevolucaoRequestHandler(
            IDevolucaoRepository devRepo,
            IAluguelRepository aluguelRepo,
            IVeiculoRepository veiculoRepo)
        {
            _devolucaoRepository = devRepo;
            _aluguelRepository = aluguelRepo;
            _veiculoRepository = veiculoRepo;

            _validator = new RegistrarDevolucaoValidator();
        }

        public async Task<object> Handle(RegistrarDevolucaoRequest request)
        {
            var validation = _validator.Validate(request);
            if (!validation.IsValid)
                return validation.Errors.Select(x => x.ErrorMessage);

            var aluguel = await _aluguelRepository.SelecionarPorId(request.AluguelId);
            if (aluguel == null)
                return DevolucaoErrorResults.AluguelNaoEncontrado;

            var veiculo = await _veiculoRepository.SelecionarPorId(aluguel.VeiculoId);
            if (veiculo == null)
                return "Veículo não encontrado.";

            if (request.KmFinal < veiculo.KmInicial)
                return DevolucaoErrorResults.KmInvalido;

            // Cálculo simples e padronizado
            decimal valorCombustivel = 0;
            decimal valorKmExcedente = 0;
            decimal valorFinal = aluguel.ValorPrevisto + request.ValorMultas;

            var devolucao = new Devolucao(
                request.AluguelId,
                request.DataDevolucao,
                request.KmFinal,
                request.NivelTanque);

            devolucao.RegistrarValores(valorCombustivel, valorKmExcedente, request.ValorMultas, valorFinal);

            aluguel.FecharAluguel(request.DataDevolucao, request.KmFinal, request.ValorMultas, valorFinal);

            await _aluguelRepository.Atualizar(aluguel);
            await _devolucaoRepository.Adicionar(devolucao);

            return new { Mensagem = "Devolução registrada com sucesso.", ValorFinal = valorFinal };
        }
    }
}
