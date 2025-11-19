namespace LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.Criar
{
    public class CriarFuncionarioRequest
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public DateTime DataAdmissao { get; set; }
        public decimal Salario { get; set; }
    }
}
