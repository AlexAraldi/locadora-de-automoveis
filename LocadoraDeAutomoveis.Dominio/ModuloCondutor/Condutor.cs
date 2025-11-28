using LocadoraDeAutomoveis.Dominio.Compartilhado;

namespace LocadoraDeAutomoveis.Dominio.ModuloCondutor;

public class Condutor :EntidadeBase<Condutor>
{
    public Guid ClienteId { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string Cpf { get; private set; } = string.Empty;
    public string Cnh { get; private set; } = string.Empty;
    public DateTime ValidadeCnh { get; private set; }
    public string Telefone { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Endereco { get; private set; } = string.Empty;

    public bool CondutorPrincipal { get; private set; }

    public Condutor() { }

    public Condutor(
        Guid clienteId,
        string nome,
        string cpf,
        string cnh,
        DateTime validadeCnh,
        string telefone,
        string email,
        string endereco,
        bool condutorPrincipal)
    {
        Id = Guid.NewGuid();
        ClienteId = clienteId;
        Nome = nome;
        Cpf = cpf;
        Cnh = cnh;
        ValidadeCnh = validadeCnh;
        Telefone = telefone;
        Email = email;
        Endereco = endereco;
        CondutorPrincipal = condutorPrincipal;
    }

    public void Editar(
        Guid clienteId,
        string nome,
        string cpf,
        string cnh,
        DateTime validadeCnh,
        string telefone,
        string email,
        string endereco,
        bool condutorPrincipal)
    {
        ClienteId = clienteId;
        Nome = nome;
        Cpf = cpf;
        Cnh = cnh;
        ValidadeCnh = validadeCnh;
        Telefone = telefone;
        Email = email;
        Endereco = endereco;
        CondutorPrincipal = condutorPrincipal;
    }
}
