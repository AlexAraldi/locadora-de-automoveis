using LocadoraDeAutomoveis.Aplicacao.ModuloCliente.DTOs;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCliente.Commands.SelecionarTodos
{
    public class SelecionarTodosClientesRequestHandler
    {
        private readonly IClienteRepository _repository;

        public SelecionarTodosClientesRequestHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ClienteDto>> Handle(SelecionarTodosClientesRequest request)
        {
            var clientes = await _repository.SelecionarTodos();

            return clientes.Select(c => new ClienteDto
            {
                Id = c.Id,
                Tipo = (int)c.Tipo,
                Nome = c.Nome,
                Email = c.Email,
                Telefone = c.Telefone,
                Cpf = c.Cpf,
                Rg = c.Rg,
                Cnh = c.Cnh,
                Cnpj = c.Cnpj,
                RazaoSocial = c.RazaoSocial,
                InscricaoEstadual = c.InscricaoEstadual,
                Endereco = c.Endereco
            });
        }
    }
}
