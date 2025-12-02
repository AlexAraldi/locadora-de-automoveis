using LocadoraDeAutomoveis.Dominio.Compartilhado;

namespace LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomovel;

public class GrupoAutomovel: EntidadeBase<GrupoAutomovel>
{
    public string Nome { get; private set; } = string.Empty;

    public GrupoAutomovel() { }

    public GrupoAutomovel(string nome)
    {
        Id = Guid.NewGuid();
        Nome = nome;
    }

    public void Editar(string nome)
    {
        Nome = nome;
    }
}
