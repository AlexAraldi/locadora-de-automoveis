using System;

namespace LocadoraDeAutomoveis.Dominio.ModuloDevolucao
{
    public class Devolucao
    {
        public Guid Id { get; set; }
        public Guid AluguelId { get; set; }

        public DateTime DataDevolucao { get; set; }
        public int KmFinal { get; set; }
        public TanqueEnum NivelTanque { get; set; }

        public decimal ValorCombustivel { get; set; }
        public decimal ValorMultas { get; set; }
        public decimal ValorKmExcedente { get; set; }
        public decimal ValorFinal { get; set; }

        public Devolucao() { }

        public Devolucao(Guid aluguelId, DateTime dataDevolucao, int kmFinal, TanqueEnum tanque)
        {
            Id = Guid.NewGuid();
            AluguelId = aluguelId;
            DataDevolucao = dataDevolucao;
            KmFinal = kmFinal;
            NivelTanque = tanque;
        }

        public void RegistrarValores(decimal combustivel, decimal kmExc, decimal multas, decimal total)
        {
            ValorCombustivel = combustivel;
            ValorKmExcedente = kmExc;
            ValorMultas = multas;
            ValorFinal = total;
        }
    }
}
