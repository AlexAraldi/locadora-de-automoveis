
using LocadoraDeAutomoveis.Dominio.Compartilhado;
using LocadoraDeAutomoveis.Dominio.ModuloAutenticacao;

namespace LocadoraDeAutomoveis.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Cargo { get; set; }
        public DateTime DataAdmissao { get; set; }
        public decimal Salario { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        
    }
}