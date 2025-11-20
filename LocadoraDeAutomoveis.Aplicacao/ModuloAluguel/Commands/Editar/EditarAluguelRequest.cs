using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.Criar;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.Editar;

public class EditarAluguelRequest : CriarAluguelRequest
{
    public Guid Id { get; set; }
}
