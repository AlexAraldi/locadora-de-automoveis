using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.SelecionarPorId;

public class SelecionarGrupoAutomovelPorIdRequest : IRequest<object>
{
    public Guid Id { get; set; }
}
