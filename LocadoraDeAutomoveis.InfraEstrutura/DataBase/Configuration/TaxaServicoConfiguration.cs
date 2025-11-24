using LocadoraDeAutomoveis.Dominio.ModuloTaxaServico;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.Infraestrutura.Database.Configuration;

public class TaxaServicoConfiguration : IEntityTypeConfiguration<TaxaServico>
{
    public void Configure(EntityTypeBuilder<TaxaServico> builder)
    {
        builder.ToTable("TB_TaxaServico");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Valor)
            .IsRequired();

        builder.Property(x => x.TipoCalculo)
            .IsRequired();
    }
}
