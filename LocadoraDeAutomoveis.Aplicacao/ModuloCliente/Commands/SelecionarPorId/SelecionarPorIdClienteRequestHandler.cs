using LocadoraDeAutomoveis.Aplicacao.ModuloCliente.DTOs;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCliente.Commands.SelecionarPorId
{
    public class SelecionarClientePorIdRequestHandler
    {
        private readonly IClienteRepository _repository;

        public SelecionarClientePorIdRequestHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> Handle(SelecionarClientePorIdRequest request)
        {
            var cliente = await _repository.BuscarPorId(request.Id);

            if (cliente == null)
                return ClienteErrorResults.ClienteNaoEncontrado;

            return new ClienteDto
            {
                Id = cliente.Id,
                Tipo = (int)cliente.Tipo,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                Cpf = cliente.Cpf,
                Rg = cliente.Rg,
                Cnh = cliente.Cnh,
                Cnpj = cliente.Cnpj,
                RazaoSocial = cliente.RazaoSocial,
                InscricaoEstadual = cliente.InscricaoEstadual,
                Endereco = cliente.Endereco
            };
        }
    }
}
