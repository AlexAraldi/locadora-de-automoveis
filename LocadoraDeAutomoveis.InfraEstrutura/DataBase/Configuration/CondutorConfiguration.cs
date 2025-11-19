using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.InfraEstrutura.DataBase.Configuration;

public class CondutorConfiguration : IEntityTypeConfiguration<Condutor>
{
    public void Configure(EntityTypeBuilder<Condutor> builder)
    {
        builder.ToTable("TB_Condutor");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ClienteId)
            .IsRequired();

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Cpf)
            .IsRequired()
            .HasMaxLength(14);

        builder.Property(x => x.Cnh)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.ValidadeCnh)
            .IsRequired();

        builder.Property(x => x.Telefone)
            .HasMaxLength(20);

        builder.Property(x => x.Email)
            .HasMaxLength(100);

        builder.Property(x => x.Endereco)
            .HasMaxLength(200);

        builder.Property(x => x.CondutorPrincipal)
            .IsRequired();
    }
}
