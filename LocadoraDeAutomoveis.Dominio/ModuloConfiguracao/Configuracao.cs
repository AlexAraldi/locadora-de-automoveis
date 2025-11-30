using LocadoraDeAutomoveis.Dominio.Compartilhado;

namespace LocadoraDeAutomoveis.Dominio.ModuloConfiguracao
{
    public class Configuracao : EntidadeBase<Configuracao>
    {
        public decimal PrecoGasolina { get; set; }
        public decimal PrecoGas { get; set; }
        public decimal PrecoDiesel { get; set; }
        public decimal PrecoAlcool { get; set; }

        public Configuracao() { }

        public void Editar(decimal precoGasolina, decimal precoGas, decimal precoAlcool, decimal precoDiesel)
        {
            PrecoGasolina = precoGasolina;
            PrecoGas = precoGas;
            PrecoAlcool = precoAlcool;
            PrecoDiesel = precoDiesel;
        }
    }
}
