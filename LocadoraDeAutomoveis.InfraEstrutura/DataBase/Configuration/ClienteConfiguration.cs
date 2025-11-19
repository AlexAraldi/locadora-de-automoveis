using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.InfraEstrutura.DataBase.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TB_Cliente");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tipo)
                .IsRequired();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Telefone)
                .IsRequired()
                .HasMaxLength(20);

            // PF
            builder.Property(x => x.Cpf)
                .HasMaxLength(14);

            builder.Property(x => x.Rg)
                .HasMaxLength(20);

            builder.Property(x => x.Cnh)
                .HasMaxLength(20);

            // PJ
            builder.Property(x => x.Cnpj)
                .HasMaxLength(18);

            builder.Property(x => x.RazaoSocial)
                .HasMaxLength(150);

            builder.Property(x => x.InscricaoEstadual)
                .HasMaxLength(20);

            builder.Property(x => x.Endereco)
                .HasMaxLength(200);
        }
    }
}
