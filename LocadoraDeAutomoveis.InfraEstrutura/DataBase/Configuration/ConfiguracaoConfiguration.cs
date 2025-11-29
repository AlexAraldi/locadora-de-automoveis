using LocadoraDeAutomoveis.Dominio.ModuloConfiguracao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.InfraEstrutura.DataBase.Configuration
{
    public class ConfiguracaoConfiguration : IEntityTypeConfiguration<Configuracao>
    {
        public void Configure(EntityTypeBuilder<Configuracao> builder)
        {
            builder.ToTable("TB_Configuracao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PrecoGasolina)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.PrecoGas)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.PrecoDiesel)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.PrecoAlcool)
                .HasPrecision(18, 2)
                .IsRequired();
        }
    }
}
