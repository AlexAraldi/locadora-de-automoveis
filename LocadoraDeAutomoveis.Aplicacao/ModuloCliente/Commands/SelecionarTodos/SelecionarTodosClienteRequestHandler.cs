using LocadoraDeAutomoveis.Aplicacao.ModuloCliente.DTOs;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCliente.Commands.SelecionarTodos
{
    public class SelecionarTodosClientesRequestHandler : IRequestHandler<SelecionarTodosClientesRequest,IEnumerable<ClienteDto>>
    {
        private readonly IClienteRepository _repository;

        public SelecionarTodosClientesRequestHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ClienteDto>> Handle(SelecionarTodosClientesRequest request, CancellationToken cancellationToken)
        {
            var clientes = await _repository.SelecionarTodosAsync();

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
