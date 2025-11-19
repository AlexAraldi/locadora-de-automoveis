using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomovel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.InfraEstrutura.DataBase.Configuration;

public class GrupoAutomovelConfiguration : IEntityTypeConfiguration<GrupoAutomovel>
{
    public void Configure(EntityTypeBuilder<GrupoAutomovel> builder)
    {
        builder.ToTable("TB_GrupoAutomovel");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(100);
    }
}
