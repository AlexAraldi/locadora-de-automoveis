namespace LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.DTOs
{
    public class DevolucaoDto
    {
        public Guid Id { get; set; }
        public Guid AluguelId { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int KmFinal { get; set; }
        public string NivelTanque { get; set; } = string.Empty;
        public decimal ValorCombustivel { get; set; }
        public decimal ValorMultas { get; set; }
        public decimal ValorKmExcedente { get; set; }
        public decimal ValorFinal { get; set; }
    }
}
