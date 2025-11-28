using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.InfraEstrutura.DataBase.Configuration;

public class PlanoCobrancaConfiguration : IEntityTypeConfiguration<PlanoCobranca>
{
    public void Configure(EntityTypeBuilder<PlanoCobranca> builder)
    {
        builder.ToTable("TB_PlanoCobranca");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.GrupoAutomovelId)
            .IsRequired();

        builder.Property(x => x.TipoPlano)
            .IsRequired();

        builder.Property(x => x.ValorDiaria)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.ValorPorKm)
            .HasPrecision(18, 2);

        builder.Property(x => x.KmLivre);

        builder.Property(x => x.KmControladoLimite);

        builder.Property(x => x.ValorExcedenteKm)
            .HasPrecision(18, 2);
    }
}
