using LocadoraDeAutomoveis.Dominio.ModuloDevolucao;

namespace LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.Commands.Registrar
{
    public class RegistrarDevolucaoRequest
    {
        public Guid AluguelId { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int KmFinal { get; set; }
        public TanqueEnum NivelTanque { get; set; }
        public decimal ValorMultas { get; set; }
    }
}
