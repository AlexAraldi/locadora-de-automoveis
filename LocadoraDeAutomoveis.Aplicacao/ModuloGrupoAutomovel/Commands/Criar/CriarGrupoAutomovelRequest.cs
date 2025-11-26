using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.Criar;

public class CriarGrupoAutomovelRequest : IRequest<object>
{
    public string Nome { get; set; }
}
