using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using MediatR;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloCliente.Commands.Criar
{
    public class CriarClienteRequest : IRequest<object>
    {
        public TipoCliente Tipo { get; set; } 
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        // PF
        public string? Cpf { get; set; }
        public string? Rg { get; set; }
        public string? Cnh { get; set; }

        // PJ
        public string? Cnpj { get; set; }
        public string? RazaoSocial { get; set; }
        public string? InscricaoEstadual { get; set; }

        public string? Endereco { get; set; }
    }
}
