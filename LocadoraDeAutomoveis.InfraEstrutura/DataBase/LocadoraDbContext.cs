using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Dominio.ModuloAutenticacao;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Dominio.ModuloDevolucao;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.Dominio.ModuloVeiculo;
using LocadoraDeAutomoveis.InfraEstrutura.DataBase.Configuration;
using LocadoraDeAutomoveis.InfraEstrutura.ModuloDevolucao.Configuration;
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
        public DbSet<GrupoAutomovel> GruposAutomovel { get; set; }
        public DbSet<Condutor> Condutores { get; set; }
        public DbSet<PlanoCobranca> PlanosCobranca { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }
        public DbSet<Devolucao> Devolucoes { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LocadoraDbContext).Assembly);

            modelBuilder.ApplyConfiguration(new VeiculoConfiguration());

            modelBuilder.ApplyConfiguration(new GrupoAutomovelConfiguration());

            modelBuilder.ApplyConfiguration(new CondutorConfiguration());

            modelBuilder.ApplyConfiguration(new PlanoCobrancaConfiguration());

            modelBuilder.ApplyConfiguration(new AluguelConfiguration());

            modelBuilder.ApplyConfiguration(new DevolucaoConfiguration());

        }
    }
}
