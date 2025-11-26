using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.Commands.SelecionarPorId
{
    public class SelecionarDevolucaoPorIdRequest : IRequest<object>
    {
        public Guid Id { get; set; }
    }
}
