using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.SelecionarPorId
{
    public class SelecionarFuncionarioPorIdRequest : IRequest <object>
    {
        public Guid Id { get; set; }
    }
}
