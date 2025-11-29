namespace LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracao.DTOs
{
    public class ConfiguracaoDto
    {
        public Guid Id { get; set; }
        public decimal PrecoGasolina { get; set; }
        public decimal PrecoGas { get; set; }
        public decimal PrecoAlcool { get; set; }
        public decimal PrecoDiesel { get; set; }
    }
}
