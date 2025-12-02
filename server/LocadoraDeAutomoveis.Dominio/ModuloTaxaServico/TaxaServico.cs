using LocadoraDeAutomoveis.Dominio.Compartilhado;

namespace LocadoraDeAutomoveis.Dominio.ModuloTaxaServico
{
    public class TaxaServico : EntidadeBase<TaxaServico>
    {
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
        public TipoCalculoTaxa TipoCalculo { get; private set; }

        public TaxaServico(string nome, decimal valor, TipoCalculoTaxa tipoCalculo)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Valor = valor;
            TipoCalculo = tipoCalculo;
        }

        public void Editar(string nome, decimal valor, TipoCalculoTaxa tipoCalculo)
        {
            Nome = nome;
            Valor = valor;
            TipoCalculo = tipoCalculo;
        }
    }
}
