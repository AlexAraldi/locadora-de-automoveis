using LocadoraDeAutomoveis.Dominio.ModuloAutenticacao;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using LocadoraDeAutomoveis.Dominio.ModuloVeiculo;
using LocadoraDeAutomoveis.InfraEstrutura.DataBase.Configuration;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.Infraestrutura.DataBase
{
    public class LocadoraDbContext : DbContext
    {
        public LocadoraDbContext(DbContextOptions<LocadoraDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; } 
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LocadoraDbContext).Assembly);

            modelBuilder.ApplyConfiguration(new VeiculoConfiguration());


           
        }

       

    }
}
