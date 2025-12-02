using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Validators;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Dominio.ModuloVeiculo;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomovel;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.Criar;

public class CriarAluguelRequestHandler : IRequestHandler<CriarAluguelRequest, object>
{
    private readonly IAluguelRepository _repository;
    private readonly IClienteRepository _clienteRepository;
    private readonly ICondutorRepository _condutorRepository;
    private readonly IVeiculoRepository _veiculoRepository;
    private readonly IPlanoCobrancaRepository _planoRepository;
    private readonly IGrupoAutomovelRepository _grupoRepository;

    private readonly CriarAluguelValidator _validator;

    public CriarAluguelRequestHandler(
        IAluguelRepository repository,
        IClienteRepository clienteRepository,
        ICondutorRepository condutorRepository,
        IVeiculoRepository veiculoRepository,
        IPlanoCobrancaRepository planoRepository,
        IGrupoAutomovelRepository grupoRepository)
    {
        _repository = repository;
        _clienteRepository = clienteRepository;
        _condutorRepository = condutorRepository;
        _veiculoRepository = veiculoRepository;
        _planoRepository = planoRepository;
        _grupoRepository = grupoRepository;

        _validator = new CriarAluguelValidator();
    }

    public async Task<object> Handle(CriarAluguelRequest request, CancellationToken cancellationToken)
    {
        var validation = _validator.Validate(request);
        if (!validation.IsValid)
            return validation.Errors.Select(x => x.ErrorMessage);

        if (await _clienteRepository.SelecionarPorIdAsync(request.ClienteId) is null)
            return AluguelErrorResults.ClienteNaoEncontrado;

        if (await _condutorRepository.SelecionarPorIdAsync(request.CondutorId) is null)
            return AluguelErrorResults.CondutorNaoEncontrado;

        if (await _grupoRepository.SelecionarPorIdAsync(request.GrupoAutomovelId) is null)
            return AluguelErrorResults.GrupoNaoEncontrado;

        var veiculo = await _veiculoRepository.SelecionarPorIdAsync(request.VeiculoId);
        if (veiculo is null)
            return AluguelErrorResults.VeiculoNaoEncontrado;

        if (await _repository.VeiculoEstaAlugadoAsync(request.VeiculoId))
            return AluguelErrorResults.VeiculoIndisponivel;

        var plano = await _planoRepository.SelecionarPorIdAsync(request.PlanoCobrancaId);
        if (plano is null)
            return AluguelErrorResults.PlanoNaoEncontrado;

        // 🔥 CÁLCULO DAS DIÁRIAS
        int dias = (int)Math.Ceiling((request.DataPrevistaTermino - request.DataInicio).TotalDays);
        if (dias < 1) dias = 1;

        // 🔥 CÁLCULO DO VALOR PREVISTO
        decimal valorPrevisto = plano.TipoPlano switch
        {
            TipoPlano.Diario => plano.ValorDiaria * dias,

            TipoPlano.KmLivre => plano.ValorDiaria * dias,

            TipoPlano.KmControlado => plano.ValorDiaria * dias, // excesso será cobrado na devolução

            _ => 0
        };

        var aluguel = new Aluguel(
            request.ClienteId,
            request.CondutorId,
            request.VeiculoId,
            request.GrupoAutomovelId,
            request.PlanoCobrancaId,
            request.DataInicio,
            request.DataPrevistaTermino,
            valorPrevisto);

        await _repository.AdicionarAsync(aluguel);

        return new
        {
            Mensagem = "Aluguel criado com sucesso.",
            Id = aluguel.Id,
            ValorPrevisto = aluguel.ValorPrevisto
        };
    }
}
