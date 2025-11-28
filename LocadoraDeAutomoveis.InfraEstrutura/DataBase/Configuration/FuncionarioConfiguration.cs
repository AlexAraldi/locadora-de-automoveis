using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.InfraEstrutura.DataBase.Configuration
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("TB_Funcionario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Cargo)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(x => x.DataAdmissao)
                .IsRequired();

            builder.Property(x => x.Salario)
               .HasPrecision(18, 2)
                .IsRequired();

            builder.HasOne(c => c.Usuario)
               .WithOne()
               .HasForeignKey<Funcionario>(f => f.UsuarioId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}