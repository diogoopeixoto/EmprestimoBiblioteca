using AutoMapper;
using GerenciadorDeBiblioteca.Api.Config;
using GerenciadorDeBiblioteca.Api.Data;
using GerenciadorDeBiblioteca.Api.Interface;
using GerenciadorDeBiblioteca.Api.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LivrosDbContext>(options =>
         options.UseSqlServer(builder.Configuration.GetConnectionString("SqlContext") ?? throw new InvalidOperationException("Connection string 'LivrosDbContext' not found.")));

//Auto Mapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
