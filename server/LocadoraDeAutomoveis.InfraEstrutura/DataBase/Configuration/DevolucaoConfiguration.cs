using LocadoraDeAutomoveis.Dominio.ModuloDevolucao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.InfraEstrutura.ModuloDevolucao.Configuration
{
    public class DevolucaoConfiguration : IEntityTypeConfiguration<Devolucao>
    {
        public void Configure(EntityTypeBuilder<Devolucao> builder)
        {
            builder.ToTable("TB_Devolucao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.AluguelId).IsRequired();
            builder.Property(x => x.DataDevolucao).IsRequired();
            builder.Property(x => x.KmFinal).IsRequired();
            builder.Property(x => x.NivelTanque).IsRequired();

            builder.Property(x => x.ValorCombustivel).HasPrecision(18, 2);
            builder.Property(x => x.ValorMultas).HasPrecision(18, 2);
            builder.Property(x => x.ValorKmExcedente).HasPrecision(18, 2);
            builder.Property(x => x.ValorFinal).HasPrecision(18, 2);
        }
    }
}
