using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloAutenticacao;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCliente.Commands.Criar
{
    public class CriarClienteRequestHandler : IRequestHandler<CriarClienteRequest, object>
    {
        private readonly IClienteRepository _repository;
        private readonly ITenantProvider _tenantProvider;
        private readonly CriarClienteValidator _validator;

        public CriarClienteRequestHandler(IClienteRepository repository, ITenantProvider tenantProvider)
        {
            _repository = repository;
            _tenantProvider = tenantProvider;
            _validator = new CriarClienteValidator();
        }

        public async Task<object> Handle(CriarClienteRequest request, CancellationToken cancellationToken)
        {
            // Valida duplicidade
            if (!string.IsNullOrWhiteSpace(request.Cpf))
            {
                var existe = await _repository.BuscarPorCpfAsync(request.Cpf);
                if (existe != null)
                    return ClienteErrorResults.CpfJaRegistrado;
            }

            if (!string.IsNullOrWhiteSpace(request.Cnpj))
            {
                var existe = await _repository.BuscarPorCnpjAsync(request.Cnpj);
                if (existe != null)
                    return ClienteErrorResults.CnpjJaRegistrado;
            }

            var cliente = new Cliente
            {
                Id = Guid.NewGuid(),
                EmpresaId = _tenantProvider.EmpresaId.Value,  
                Tipo = (TipoCliente)request.Tipo,
                Nome = request.Nome,
                Email = request.Email,
                Telefone = request.Telefone,
                Cpf = request.Cpf,
                Rg = request.Rg,
                Cnh = request.Cnh,
                Cnpj = request.Cnpj,
                RazaoSocial = request.RazaoSocial,
                InscricaoEstadual = request.InscricaoEstadual,
                Endereco = request.Endereco
            };

            await _repository.AdicionarAsync(cliente);

            return new
            {
                Mensagem = "Cliente cadastrado com sucesso.",
                ClienteId = cliente.Id
            };
        }
    }
}
