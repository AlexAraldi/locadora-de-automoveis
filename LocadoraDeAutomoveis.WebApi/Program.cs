using Microsoft.EntityFrameworkCore;
using FluentValidation;
using LocadoraDeAutomoveis.InfraEstrutura.ModuloAutenticacao.Repositories;
using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Commands.Autenticar;
using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Service;
using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Commands.Registrar;
using LocadoraDeAutomoveis.Aplicacao.ModuloAutenticacao.Validators;
using LocadoraDeAutomoveis.Infraestrutura.DataBase;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using LocadoraDeAutomoveis.InfraEstrutura.ModuloFuncionario.Repositories;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.Editar;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.Excluir;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.SelecionarPorId;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.SelecionarTodos;
using LocadoraDeAutomoveis.Aplicacao.ModuloFuncionario.Commands.Criar;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.InfraEstrutura.ModuloCliente.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB
builder.Services.AddDbContext<LocadoraDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Autenticação
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<AutenticarUsuarioRequestHandler>();

builder.Services.AddValidatorsFromAssembly(typeof(AutenticarUsuarioRequest).Assembly);

builder.Services.AddSingleton(new JwtService(builder.Configuration["Jwt:Key"]));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
builder.Services.AddScoped<RegistrarUsuarioRequestHandler>();
builder.Services.AddScoped<RegistrarUsuarioValidator>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();

builder.Services.AddScoped<CriarFuncionarioRequestHandler>();
builder.Services.AddScoped<EditarFuncionarioRequestHandler>();
builder.Services.AddScoped<ExcluirFuncionarioRequestHandler>();
builder.Services.AddScoped<SelecionarFuncionarioPorIdRequestHandler>();
builder.Services.AddScoped<SelecionarTodosFuncionariosRequestHandler>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();


