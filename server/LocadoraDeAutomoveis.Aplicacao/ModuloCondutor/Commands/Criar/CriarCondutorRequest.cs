using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Commands.Criar;

public class CriarCondutorRequest : IRequest<object>
{
    public Guid ClienteId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Cnh { get; set; } = string.Empty;
    public DateTime ValidadeCnh { get; set; }
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public bool CondutorPrincipal { get; set; }
}
