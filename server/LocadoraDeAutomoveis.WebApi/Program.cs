using Microsoft.EntityFrameworkCore;
using FluentValidation;
using MediatR;


// Autentica��o
using LocadoraDeAutomoveis.InfraEstrutura.ModuloAutenticacao.Repositories;
using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Commands.Autenticar;
using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Service;
using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Commands.Registrar;
using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Validators;

// Banco de Dados
using LocadoraDeAutomoveis.Infraestrutura.DataBase;

// Funcion�rio
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using LocadoraDeAutomoveis.InfraEstrutura.ModuloFuncionario.Repositories;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.Criar;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.Excluir;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.SelecionarTodos;

// Cliente
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.InfraEstrutura.ModuloCliente.Repositories;

// Ve�culo
using LocadoraDeAutomoveis.Dominio.ModuloVeiculo;
using LocadoraDeAutomoveis.InfraEstrutura.ModuloVeiculo.Repositories;
using LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.Criar;
using LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.Excluir;
using LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloVeiculo.Commands.SelecionarTodos;

// Grupo Autom�vel
using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraDeAutomoveis.InfraEstrutura.ModuloGrupoAutomovel.Repositories;
using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.Criar;
using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.Excluir;
using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloGrupoAutomovel.Commands.SelecionarTodos;

// Condutor
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.InfraEstrutura.ModuloCondutor.Repositories;
using LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Commands.Criar;
using LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Commands.Excluir;
using LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloCondutor.Commands.SelecionarTodos;

// Configura��o
using LocadoraDeAutomoveis.Dominio.ModuloConfiguracao;
using LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracao.Commands.Selecionar;


// Plano de Cobran�a
using LocadoraDeAutomoveis.InfraEstrutura.ModuloPlanoCobranca.Repositories;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.Criar;
using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.Excluir;
using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloPlanoCobranca.Commands.SelecionarTodos;

// Aluguel
using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.Criar;
using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.Excluir;
using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloAluguel.Commands.SelecionarTodos;
using LocadoraDeAutomoveis.Dominio.ModuloAluguel;
using LocadoraDeAutomoveis.InfraEstrutura.ModuloAluguel.Repositories;

// Devolu��o
using LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.Commands.Registrar;
using LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloDevolucao.Commands.SelecionarTodos;
using LocadoraDeAutomoveis.Dominio.ModuloDevolucao;
using LocadoraDeAutomoveis.InfraEstrutura.ModuloDevolucao.Repositories;

// Taxa Servi�o
using LocadoraDeAutomoveis.Dominio.ModuloTaxaServico;
using LocadoraDeAutomoveis.Infraestrutura.ModuloTaxaServico.Repositories;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.Criar;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.Excluir;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Commands.SelecionarTodos;
using LocadoraDeAutomoveis.Aplicacao.ModuloTaxaServico.Validators;

// JWT
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using LocadoraDeAutomoveis.Dominio.ModuloAutenticacao;
using Microsoft.AspNetCore.Identity;
using LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracao.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloConfiguracao.Commands.Criar;
using LocadoraDeAutomoveis.InfraEstrutura.ModuloConfiguracao.Repositories;


var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
    policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});


// ============================================================================
// SERVI�OS B�SICOS
// ============================================================================
builder.Services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddEndpointsApiExplorer();

// ============================================================================
// SWAGGER + JWT
// ============================================================================
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Locadora de Veículos API", Version = "v1" });

    c.MapType<TimeSpan>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "time-span",
        Example = new Microsoft.OpenApi.Any.OpenApiString("00:00:00")
    });

    c.MapType<Guid>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "guid",
        Example = new Microsoft.OpenApi.Any.OpenApiString("00000000-0000-0000-0000-000000000000")
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Informe o token JWT no padrão ",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        []
    }
});
});

// ============================================================================
// MEDIATR
// ============================================================================
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CriarTaxaServicoRequestHandler).Assembly));

// ============================================================================
// BANCO DE DADOS
// ============================================================================
builder.Services.AddDbContext<LocadoraDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// ============================================================================
// AUTENTICA��O JWT
// ============================================================================

builder.Services.AddScoped<ITenantProvider, IdentityTenantProvider>();
builder.Services.AddIdentity<Usuario, Cargo>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
        .AddEntityFrameworkStores<LocadoraDbContext>()
        .AddDefaultTokenProviders();


builder.Services
    .AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT_GENERATION_KEY"])
            )
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<AutenticarUsuarioRequestHandler>();
builder.Services.AddScoped<RegistrarUsuarioRequestHandler>();
builder.Services.AddScoped<RegistrarUsuarioValidator>();
builder.Services.AddValidatorsFromAssembly(typeof(AutenticarUsuarioRequest).Assembly);
builder.Services.AddScoped<JwtService>();

// ============================================================================
// FUNCION�RIO
// ============================================================================
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddScoped<CriarFuncionarioRequestHandler>();
builder.Services.AddScoped<EditarFuncionarioRequestHandler>();
builder.Services.AddScoped<ExcluirFuncionarioRequestHandler>();
builder.Services.AddScoped<SelecionarFuncionarioPorIdRequestHandler>();
builder.Services.AddScoped<SelecionarTodosFuncionariosRequestHandler>();

// ============================================================================
// CONFIGURA��O
// ============================================================================
builder.Services.AddScoped<IConfiguracaoRepository, ConfiguracaoRepository>();
builder.Services.AddScoped<CriarConfiguracaoRequestHandler>();
builder.Services.AddScoped<EditarConfiguracaoRequestHandler>();
builder.Services.AddScoped<SelecionarConfiguracaoRequestHandler>();

// ============================================================================
// CLIENTE
// ============================================================================
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

// ============================================================================
// VE�CULO
// ============================================================================
builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();
builder.Services.AddScoped<CriarVeiculoRequestHandler>();
builder.Services.AddScoped<EditarVeiculoRequestHandler>();
builder.Services.AddScoped<ExcluirVeiculoRequestHandler>();
builder.Services.AddScoped<SelecionarVeiculoPorIdRequestHandler>();
builder.Services.AddScoped<SelecionarTodosVeiculosRequestHandler>();

// ============================================================================
// GRUPO AUTOM�VEL
// ============================================================================
builder.Services.AddScoped<IGrupoAutomovelRepository, GrupoAutomovelRepository>();
builder.Services.AddScoped<CriarGrupoAutomovelRequestHandler>();
builder.Services.AddScoped<EditarGrupoAutomovelRequestHandler>();
builder.Services.AddScoped<ExcluirGrupoAutomovelRequestHandler>();
builder.Services.AddScoped<SelecionarGrupoAutomovelPorIdRequestHandler>();
builder.Services.AddScoped<SelecionarTodosGruposAutomovelRequestHandler>();

// ============================================================================
// CONDUTOR
// ============================================================================
builder.Services.AddScoped<ICondutorRepository, CondutorRepository>();
builder.Services.AddScoped<CriarCondutorRequestHandler>();
builder.Services.AddScoped<EditarCondutorRequestHandler>();
builder.Services.AddScoped<ExcluirCondutorRequestHandler>();
builder.Services.AddScoped<SelecionarCondutorPorIdRequestHandler>();
builder.Services.AddScoped<SelecionarTodosCondutoresRequestHandler>();

// ============================================================================
// PLANO DE COBRAN�A
// ============================================================================
builder.Services.AddScoped<IPlanoCobrancaRepository, PlanoCobrancaRepository>();
builder.Services.AddScoped<CriarPlanoCobrancaRequestHandler>();
builder.Services.AddScoped<EditarPlanoCobrancaRequestHandler>();
builder.Services.AddScoped<ExcluirPlanoCobrancaRequestHandler>();
builder.Services.AddScoped<SelecionarPlanoCobrancaPorIdRequestHandler>();
builder.Services.AddScoped<SelecionarTodosPlanosCobrancaRequestHandler>();

// ============================================================================
// ALUGUEL
// ============================================================================
builder.Services.AddScoped<IAluguelRepository, AluguelRepository>();
builder.Services.AddScoped<CriarAluguelRequestHandler>();
builder.Services.AddScoped<EditarAluguelRequestHandler>();
builder.Services.AddScoped<ExcluirAluguelRequestHandler>();
builder.Services.AddScoped<SelecionarAluguelPorIdRequestHandler>();
builder.Services.AddScoped<SelecionarTodosAlugueisRequestHandler>();

// ============================================================================
// DEVOLU��O
// ============================================================================
builder.Services.AddScoped<IDevolucaoRepository, DevolucaoRepository>();
builder.Services.AddScoped<RegistrarDevolucaoRequestHandler>();
builder.Services.AddScoped<SelecionarDevolucaoPorIdRequestHandler>();
builder.Services.AddScoped<SelecionarTodasDevolucoesRequestHandler>();

// ============================================================================
// TAXA SERVI�O
// ============================================================================
builder.Services.AddScoped<ITaxaServicoRepository, TaxaServicoRepository>();
builder.Services.AddScoped<CriarTaxaServicoRequestHandler>();
builder.Services.AddScoped<EditarTaxaServicoRequestHandler>();
builder.Services.AddScoped<ExcluirTaxaServicoRequestHandler>();
builder.Services.AddScoped<SelecionarTaxaServicoPorIdRequestHandler>();
builder.Services.AddScoped<SelecionarTodosTaxasServicoRequestHandler>();
builder.Services.AddScoped<CriarTaxaServicoValidator>();
builder.Services.AddScoped<EditarTaxaServicoValidator>();

// ============================================================================
// PIPELINE
// ============================================================================
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);


// JWT Middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
