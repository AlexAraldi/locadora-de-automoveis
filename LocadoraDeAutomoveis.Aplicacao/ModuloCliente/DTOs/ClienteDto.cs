namespace LocadoraDeAutomoveis.Aplicacao.ModuloCliente.DTOs
{
    public class ClienteDto
    {
        public Guid Id { get; set; }

        public int Tipo { get; set; } // 1 = PF, 2 = PJ

        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }

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
