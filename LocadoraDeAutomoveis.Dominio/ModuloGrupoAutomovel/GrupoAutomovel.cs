namespace LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomovel;

public class GrupoAutomovel
{
    public Guid Id { get; private set; }
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
