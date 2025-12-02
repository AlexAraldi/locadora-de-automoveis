using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.Excluir;

public class ExcluirGrupoAutomovelRequest : IRequest<object>
{
    public Guid Id { get; set; }
}
