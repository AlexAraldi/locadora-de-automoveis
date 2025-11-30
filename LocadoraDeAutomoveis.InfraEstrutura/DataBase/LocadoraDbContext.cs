using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.Dominio.ModuloAutenticacao;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Dominio.ModuloConfiguracao;
using LocadoraDeAutomoveis.Dominio.ModuloDevolucao;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.Dominio.ModuloTaxaServico;
using LocadoraDeAutomoveis.Dominio.ModuloVeiculo;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeAutomoveis.Infraestrutura.DataBase
{
    public class LocadoraDbContext : IdentityDbContext<Usuario, Cargo, Guid>
    {
        private readonly ITenantProvider? tenantProvider;

        public LocadoraDbContext(DbContextOptions<LocadoraDbContext> options, ITenantProvider? tenantProvider = null)
            : base(options)
        {
            this.tenantProvider = tenantProvider;
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
        public DbSet<TaxaServico> TaxasServico { get; set; }
        public DbSet<Configuracao> Configuracoes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (tenantProvider is not null)
            {
                modelBuilder.Entity<Aluguel>()
                    .HasQueryFilter(f => f.EmpresaId == tenantProvider.EmpresaId.GetValueOrDefault());
                modelBuilder.Entity<Cliente>()
                    .HasQueryFilter(f => f.EmpresaId == tenantProvider.EmpresaId.GetValueOrDefault());
                modelBuilder.Entity<Condutor>()
                    .HasQueryFilter(f => f.EmpresaId == tenantProvider.EmpresaId.GetValueOrDefault());
                modelBuilder.Entity<Devolucao>()
                    .HasQueryFilter(f => f.EmpresaId == tenantProvider.EmpresaId.GetValueOrDefault());
                modelBuilder.Entity<Funcionario>()
                    .HasQueryFilter(f => f.EmpresaId == tenantProvider.EmpresaId.GetValueOrDefault());
                modelBuilder.Entity<GrupoAutomovel>()
                    .HasQueryFilter(f => f.EmpresaId == tenantProvider.EmpresaId.GetValueOrDefault());
                modelBuilder.Entity<PlanoCobranca>()
                    .HasQueryFilter(f => f.EmpresaId == tenantProvider.EmpresaId.GetValueOrDefault());
                modelBuilder.Entity<TaxaServico>()
                    .HasQueryFilter(f => f.EmpresaId == tenantProvider.EmpresaId.GetValueOrDefault());
                modelBuilder.Entity<Veiculo>()
                    .HasQueryFilter(f => f.EmpresaId == tenantProvider.EmpresaId.GetValueOrDefault());
                modelBuilder.Entity<Configuracao>()
                    .HasQueryFilter(f => f.EmpresaId == tenantProvider.EmpresaId.GetValueOrDefault());

            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LocadoraDbContext).Assembly);

            base.OnModelCreating(modelBuilder);

        }
    }
}