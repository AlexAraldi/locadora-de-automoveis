using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.InfraEstrutura.DataBase.Configuration;

public class AluguelConfiguration : IEntityTypeConfiguration<Aluguel>
{
    public void Configure(EntityTypeBuilder<Aluguel> builder)
    {
        builder.ToTable("TB_Aluguel");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ClienteId).IsRequired();
        builder.Property(x => x.CondutorId).IsRequired();
        builder.Property(x => x.VeiculoId).IsRequired();
        builder.Property(x => x.GrupoAutomovelId).IsRequired();
        builder.Property(x => x.PlanoCobrancaId).IsRequired();

        builder.Property(x => x.DataInicio)
            .IsRequired();

        builder.Property(x => x.DataPrevistaTermino)
            .IsRequired();

        builder.Property(x => x.ValorPrevisto)
             .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.ValorFinal)
             .HasPrecision(18, 2);

        builder.Property(x => x.ValorMultas)
             .HasPrecision(18, 2);

        builder.Property(x => x.KmFinal);

        builder.Property(x => x.Situacao)
            .IsRequired();
    }
}
