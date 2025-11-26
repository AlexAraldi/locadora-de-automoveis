using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.Excluir
{
    public class ExcluirFuncionarioRequest : IRequest<object>
    {
        public Guid Id { get; set; }
    }
}
