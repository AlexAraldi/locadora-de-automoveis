using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.Editar;

public class EditarGrupoAutomovelRequest : IRequest<object>
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
}
