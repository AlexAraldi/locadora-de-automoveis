using LocadoraDeAutomoveis.Dominio.Compartilhado;

namespace LocadoraDeAutomoveis.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase<Cliente>    
    {
        // Tipo: PF ou PJ
        public TipoCliente Tipo { get; set; }

        // Propriedades comuns
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // PF (nullable)
        public string? Cpf { get; set; }
        public string? Rg { get; set; }
        public string? Cnh { get; set; }

        // PJ (nullable)
        public string? Cnpj { get; set; }
        public string? RazaoSocial { get; set; }
        public string? InscricaoEstadual { get; set; }

        // Endereço
        public string? Endereco { get; set; }

        public Cliente() { }

        public Cliente(
            TipoCliente tipo,
            string nome,
            string email,
            string telefone,
            string? cpf = null,
            string? rg = null,
            string? cnh = null,
            string? cnpj = null,
            string? razaoSocial = null,
            string? inscricaoEstadual = null,
            string? endereco = null
        )
        {
            Id = Guid.NewGuid();
            Tipo = tipo;
            Nome = nome;
            Email = email;
            Telefone = telefone;

            Cpf = cpf;
            Rg = rg;
            Cnh = cnh;

            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
            InscricaoEstadual = inscricaoEstadual;

            Endereco = endereco;
        }
    }
}
