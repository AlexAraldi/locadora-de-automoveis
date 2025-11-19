using LocadoraDeAutomoveis.Dominio.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.InfraEstrutura.DataBase.Configuration;

public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
{
    public void Configure(EntityTypeBuilder<Veiculo> builder)
    {
        builder.ToTable("TB_Veiculo");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Modelo)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Marca)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Ano)
            .IsRequired();

        builder.Property(x => x.Placa)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(x => x.Quilometragem)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

        builder.Property(x => x.Combustivel)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(x => x.Ativo)
            .IsRequired();
    }
}
