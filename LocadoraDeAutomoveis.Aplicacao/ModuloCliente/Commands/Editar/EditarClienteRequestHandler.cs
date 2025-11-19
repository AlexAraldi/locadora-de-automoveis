using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using MediatR;


namespace LocadoraDeAutomoveis.Aplicacao.ModuloCliente.Commands.Editar
{
    public class EditarClienteRequestHandler : IRequestHandler<EditarClienteRequest, object>
    {
        private readonly IClienteRepository _repository;

        public EditarClienteRequestHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> Handle(EditarClienteRequest request, CancellationToken cancellationToken)
        {
            var cliente = await _repository.BuscarPorId(request.Id);

            if (cliente == null)
                return ClienteErrorResults.ClienteNaoEncontrado;

            cliente.Tipo = (TipoCliente)request.Tipo;
            cliente.Nome = request.Nome;
            cliente.Email = request.Email;
            cliente.Telefone = request.Telefone;

            cliente.Cpf = request.Cpf;
            cliente.Rg = request.Rg;
            cliente.Cnh = request.Cnh;

            cliente.Cnpj = request.Cnpj;
            cliente.RazaoSocial = request.RazaoSocial;
            cliente.InscricaoEstadual = request.InscricaoEstadual;

            cliente.Endereco = request.Endereco;

            await _repository.Atualizar(cliente);

            return new { Mensagem = "Cliente atualizado com sucesso." };
        }
    }
}
